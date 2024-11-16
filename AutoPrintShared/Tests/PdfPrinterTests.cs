using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using AutoPrintShared.Interfaces;
using PdfiumViewer;
using System.IO;

namespace AutoPrintShared.Tests
{
    public class PdfPrinterTests
    {
        private readonly Mock<ILogger> _mockLogger;
        private readonly Mock<IServiceError> _mockServiceError;
        private readonly Mock<IAutoPrintSetup> _mockAutoPrintSetup;
        private readonly PdfPrinter _pdfPrinter;

        public PdfPrinterTests()
        {
            _mockLogger = new Mock<ILogger>();
            _mockServiceError = new Mock<IServiceError>();
            _mockAutoPrintSetup = new Mock<IAutoPrintSetup>();
            _pdfPrinter = new PdfPrinter(_mockAutoPrintSetup.Object);
        }

        [Fact]
        public async Task PrintPdf_ShouldPrintSuccessfully()
        {
            // Arrange
            var filePath = "valid_document.pdf";
            _mockAutoPrintSetup.Setup(a => a.OutPutFolder).Returns("output_folder");

            // Act
            await _pdfPrinter.PrintPdf(filePath);

            // Assert
            _mockLogger.Verify(l => l.AddEntry(It.IsAny<string>(), "Error"), Times.Once);
            _mockServiceError.Verify(s => s.ErrorActivity(It.IsAny<string>()), Times.Never);
            Assert.True(File.Exists(Path.Combine("output_folder", Path.GetFileName(filePath))));
            Assert.False(File.Exists(filePath)); // Ensure the original file is deleted
        }

        [Fact]
        public async Task PrintPdf_ShouldLogError_WhenExceptionOccurs()
        {
            // Arrange
            var filePath = "C:\\Users\\Baskar\\Desktop\\sampleCopyIINIIM.pdf";
            var mockPdfLoader = new Mock<IPdfPrinter>();

            // Simulate an exception when loading the PDF
            //mockPdfLoader.Setup(loader => loader.PrintPdf(filePath)).Throws(new Exception("Load error"));

            _mockAutoPrintSetup.Setup(a => a.OutPutFolder).Returns("C:\\AutoPrint\\OutputFolder");

            var pdfPrinter = new PdfPrinter(_mockAutoPrintSetup.Object);

            // Act
            await pdfPrinter.PrintPdf(filePath);

            // Assert
            _mockLogger.Verify(l => l.AddEntry(It.IsAny<string>(), "Error"), Times.Never);
            _mockServiceError.Verify(s => s.ErrorActivity(It.IsAny<string>()), Times.Once);
        }

    }
}
