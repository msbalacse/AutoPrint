using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintShared.Interfaces
{
    public interface IPdfPrinter
    {
        Task PrintPdf(string filePath);
        void CopyFile(string sourceFilePath, string destinationDirectory);
    }
}
