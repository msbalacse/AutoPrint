using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintShared.Interfaces
{
    public interface IAutoPrintSetup
    {
        string HubFolder { get; set; }
        string OutPutFolder { get; set; }
        string LogFile { get; set; }
        string ValidFiles { get; set; }
    }
}
