using System;
using System.Collections.Generic;
using System.IO;
using AutoPrintShared.Interfaces;
using AutoPrintShared.Logger;
using Newtonsoft.Json;

namespace AutoPrintShared
{
    public class JsonLogger : ILogger
    {
        private readonly string _jsonLogFilePath;
        private static readonly object _lock = new object();

        public JsonLogger(string logFilePath)
        {
            _jsonLogFilePath = Path.Combine(logFilePath, "log.json");
            InitializeJsonLogFile();
        }

        private void InitializeJsonLogFile()
        {
            if (!File.Exists(_jsonLogFilePath))
            {
                File.WriteAllText(_jsonLogFilePath, "[]");
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

        public void AddLogEntryToFile(LogEntry logEntry)
        {
            try
            {
                lock (_lock)
                {
                    var jsonEntry = JsonConvert.SerializeObject(logEntry);
                    var jsonArray = File.ReadAllText(_jsonLogFilePath);

                    if (jsonArray.Trim() == "[]")
                    {
                        jsonArray = jsonArray.TrimEnd(']') + jsonEntry + "]";
                    }
                    else
                    {
                        jsonArray = jsonArray.TrimEnd(']') + "," + jsonEntry + "]";
                    }

                    File.WriteAllText(_jsonLogFilePath, jsonArray);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (optional)
            }
        }

        public List<LogEntry> GetLogEntries()
        {
            lock (_lock)
            {
                var jsonArray = File.ReadAllText(_jsonLogFilePath);
                return JsonConvert.DeserializeObject<List<LogEntry>>(jsonArray);
            }
        }
    }
}
