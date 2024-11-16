using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintShared.Model
{
    public class RecentFile
    {
        public string FileName { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime LastAccessed { get; set; }

        public RecentFile(string fileName, DateTime lastAccessed, string message = "", string type = "Info")
        {
            FileName = fileName;
            LastAccessed = lastAccessed;
            Message = message;
            Type = type;
        }

        public override string ToString()
        {
            return $"File Name: {FileName}, Last Accessed: {LastAccessed}";
        }
    }
}
