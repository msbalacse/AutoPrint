using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintShared.Logger
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Info { get; set; }
        public string Message { get; set; }
    }
}
