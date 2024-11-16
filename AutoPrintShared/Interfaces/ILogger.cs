using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintShared.Interfaces
{
    public interface ILogger
    {
        void AddEntry(string level, string message);
    }
}
