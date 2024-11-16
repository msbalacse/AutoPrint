using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration.Install;

namespace AutoPrint
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //try
            //{
            //    var installer = new AutoPrintServiceInstaller();
            //    var servicesRunner = new Dictionary<string, object>
            //    {
            //        { "AutoPrintService", new AutoPrintService() }
            //    };

            //    installer.Install(servicesRunner);
            //}
            //catch (Exception ex) { }


            Application.Run(new AutoPrint());
        }
    }
}
