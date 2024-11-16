using System;
using System.IO;
using System.Threading.Tasks;
using AutoPrintShared.Interfaces;
using AutoPrintShared.Model;
using PdfiumViewer;

namespace AutoPrintShared
{
    public class PdfPrinter : IPdfPrinter
    {

        public ServiceError _serviceError = new ServiceError();

        private IAutoPrintSetup _autoPrintSetup = null;
        private ILogger _xmlLogger = null;
        private ILogger _jsonLogger = null;
        public PdfPrinter(IAutoPrintSetup autoPrintSetup)
        {
            _autoPrintSetup = autoPrintSetup;
            _xmlLogger = new XmlLogger(autoPrintSetup.LogFile);
            _jsonLogger = new JsonLogger(autoPrintSetup.LogFile);
        }
        public async Task PrintPdf(string filePath)
        {
            try
            {
                using (var document = PdfDocument.Load(filePath))
                {
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        await Task.Run(() => printDocument.Print());
                    }
                }
                CopyFile(filePath, _autoPrintSetup.OutPutFolder);
                _xmlLogger.AddEntry("Success",$"File printed : {Path.GetFileName(filePath)}");
                _jsonLogger.AddEntry("Success", $"File printed : {Path.GetFileName(filePath)}");
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                _serviceError.ErrorActivity("Load error : " + ex.Message);
            }
            finally
            {
            }
        }

        public void CopyFile(string sourceFilePath, string destinationDirectory)
        {
            try
            {
                if (!File.Exists(sourceFilePath)) return;


                string fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
                string fileExtension = Path.GetExtension(sourceFilePath);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string newFileName = $"{timestamp}_{fileName}{fileExtension}";
                string destinationFilePath = Path.Combine(destinationDirectory, newFileName);

                File.Copy(sourceFilePath, destinationFilePath);
            }
            catch (Exception ex) { }
        }
    }
}
