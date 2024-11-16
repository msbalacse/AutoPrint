using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintShared
{
    public class ServiceError
    {
        string diskPath = "C:";
        public ServiceError() { }

        public void ErrorActivity(string message)
        {
            try
            {

                string path = diskPath + "\\Service_Error";
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = diskPath + "\\Service_Error\\Serviceout.txt";

                if (!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine(message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine(message);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
