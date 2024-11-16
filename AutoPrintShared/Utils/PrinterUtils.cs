using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace AutoPrintShared.Utils
{
    public class PrinterUtils
    {
        public Dictionary<string, string> PrinterStatus = null;
        public PrinterUtils()
        {
            PrinterStatus = new Dictionary<string, string>() {
                { "status", "" },
                { "isOnline", "false" }
            };
        }
        public bool CheckLivePrinters()
        {
            try
            {
                string query = "SELECT * FROM Win32_Printer WHERE Local = TRUE  AND (PortName LIKE 'USB%' OR PortName LIKE 'LPT%' OR PortName LIKE 'COM%')";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    foreach (ManagementObject printer in searcher.Get())
                    {
                        string name = printer["Name"]?.ToString();
                        bool isOnline = printer["WorkOffline"] != null && !(bool)printer["WorkOffline"];
                        string status = printer["PrinterStatus"]?.ToString();

                        PrinterStatus["status"] = status;
                        PrinterStatus["isOnline"] = isOnline.ToString();

                        if (isOnline && (status == "3" || status == null)) return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Dictionary<string, string> GetPrinterStatus()
        {
            return PrinterStatus;
        }

    }
}
