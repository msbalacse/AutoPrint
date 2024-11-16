using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPrintShared.Utils;
using Xunit;

namespace AutoPrintShared.Tests
{
    public class FileUtilsTests
    {
        private readonly FileUtils _fileUtils =  new FileUtils();

        [Theory]
        [InlineData("C:\\AutoPrint\\balasdfsdfsd.txt", "")]
        public void isValidFilename(string filename, string ValidFiles)
        {
            bool result =  _fileUtils.ValidFile(filename, ValidFiles);
            Assert.True(result);
        }
    }
}
