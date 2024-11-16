using AutoPrintShared.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintShared.Utils
{
    public class CommonUtils
    {
        private ILogger _xmlLogger = null;
        private ILogger _jsonLogger = null;
        public CommonUtils(string loggerPath)
        {
            _xmlLogger = new XmlLogger(loggerPath);
            _jsonLogger = new JsonLogger(loggerPath);
        }
        //private void setUp()
        //{
        //    string _setUp = File.ReadAllText(_autoPrintSetUpJson);
        //    autoPrintSetup = JsonSerializer.Deserialize<AutoPrintSetup>(_setUp);
        //    txtFolderPath.Text = autoPrintSetup.HubFolder;
        //    ChkDirectoryExists(autoPrintSetup.HubFolder);
        //    ChkDirectoryExists(autoPrintSetup.OutPutFolder);
        //    ChkDirectoryExists(autoPrintSetup.LogFile);
        //    logger = new Logger(autoPrintSetup.LogFile);
        //}

        public bool IsSupportedFileType(string filePath)
        {
            string[] supportedExtensions = { ".pdf" };
            string fileExtension = Path.GetExtension(filePath).ToLowerInvariant();
            return Array.Exists(supportedExtensions, ext => ext.Equals(fileExtension, StringComparison.OrdinalIgnoreCase));
        }

        public void LogUnValidFiles(string filePath)
        {
            _xmlLogger.AddEntry("Error", $"File is not Valid : {Path.GetFileName(filePath)}");
            _jsonLogger.AddEntry("Error", $"File is not Valid : {Path.GetFileName(filePath)}");
            File.Delete(filePath);
        }

        public void LogUnsupportedFileType(string filePath)
        {
            _xmlLogger.AddEntry("Error", $"File is not PDF Format: {Path.GetFileName(filePath)}");
            _jsonLogger.AddEntry("Error", $"File is not PDF Format: {Path.GetFileName(filePath)}");
            File.Delete(filePath);
        }

        public void LogFileNotAccessible(string filePath)
        {
            _xmlLogger.AddEntry("Error", $"File is not accessible: {Path.GetFileName(filePath)}");
            _jsonLogger.AddEntry("Error", $"File is not accessible: {Path.GetFileName(filePath)}");
            File.Delete(filePath);
        }

    }
}
