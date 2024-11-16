using AutoPrintShared.Interfaces;
using AutoPrintShared.Logger;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace AutoPrintShared
{
    public class XmlLogger: ILogger
    {
        private readonly string _logFilePath;
        private static readonly object _lock = new object();

        public XmlLogger(string logFilePath)
        {
            _logFilePath = logFilePath + "\\log.xml";
            try
            {
                InitializeLogFile();
            }
            catch (Exception ex)
            { }
        }

        private void InitializeLogFile()
        {
            if (!File.Exists(_logFilePath))
            {
                //File.Delete(_logFilePath);
                using (XmlWriter writer = XmlWriter.Create(_logFilePath, new XmlWriterSettings { Indent = true }))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Logs");
                    writer.WriteString(" ");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        public void AddEntry(string level, string message)
        {
            var logEntry = new LogEntry
            {
                Timestamp = DateTime.Now,
                Info = level,
                Message = message
            };

            AddLogEntryToFile(logEntry);
        }

        private void AddLogEntryToFile(LogEntry logEntry)
        {
            try
            {
                lock (_lock)
                {
                    var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };

                    using (var fileStream = new FileStream(_logFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                    {

                        XmlDocument doc = new XmlDocument();
                        doc.Load(fileStream);

                        XmlNode logNode = doc.CreateElement("LogEntry");

                        XmlNode timeNode = doc.CreateElement("Timestamp");
                        timeNode.InnerText = logEntry.Timestamp.ToString("o");
                        logNode.AppendChild(timeNode);

                        XmlNode levelNode = doc.CreateElement("Level");
                        levelNode.InnerText = logEntry.Info;
                        logNode.AppendChild(levelNode);

                        XmlNode messageNode = doc.CreateElement("Message");
                        messageNode.InnerText = logEntry.Message;
                        logNode.AppendChild(messageNode);

                        doc.DocumentElement.AppendChild(logNode);


                        fileStream.SetLength(0);
                        doc.Save(fileStream);
                    }
                }
            }
            catch (Exception ex) { }
        }

        
    }
}
