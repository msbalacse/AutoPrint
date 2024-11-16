using AutoPrintShared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintShared
{
    public class AutoPrintSetup: IAutoPrintSetup
    {
        public string HubFolder { get; set; }
        public string OutPutFolder { get; set; }
        public string LogFile { get; set; }
        public string ValidFiles { get; set; }
        public override string ToString()
        {
            return $"HubFolder: {HubFolder}, OutPutFolder: {OutPutFolder}, LogFile: {LogFile}, ValidFiles: {ValidFiles}";
        }
    }
}
