using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Threading;
using System.ServiceProcess;
using AutoPrint.Forms;
using AutoPrintShared;
using AutoPrintShared.Interfaces;
using AutoPrintShared.Utils;
using AutoPrintShared.Logger;


namespace AutoPrint
{
    public partial class AutoPrint : MetroForm
    {

        private FileSystemWatcher _watcher;
        string _autoPrintSetUpJson = "C:\\AutoPrint\\Setup\\autoprint_setup.json";
        string serviceName = "AutoPrint";

        private PrinterUtils _printerUtils = new PrinterUtils();
        private FileUtils _fileUtils = new FileUtils();

        private System.Windows.Forms.Timer _printerStatusTimer = new System.Windows.Forms.Timer();


        IAutoPrintSetup autoPrintSetup = null;

        public Dictionary<string, string> PrintStatus = new Dictionary<string, string>();

        private CancellationTokenSource _cancellationTokenSource;

        JsonLogger _jsonLogger = null;
        List<LogEntry> logEntries = new List<LogEntry>();

        public AutoPrint()
        {
            InitializeComponent();
            PrinterChecker();
            ServiceStatus();
            _fileUtils.ChkDirectoryExists(_fileUtils.GetParentPath(_autoPrintSetUpJson));
            _fileUtils.setDefaultPath(_autoPrintSetUpJson);
            setUpJson();

            _jsonLogger = new JsonLogger(autoPrintSetup.LogFile);
        }

        private void ServiceStatus()
        {
            try
            {
                using (ServiceController serviceController = new ServiceController(serviceName))
                {
                    if (serviceController.Status == ServiceControllerStatus.Stopped)
                    {
                        btnServiceHandle.Text = "Activate Service";
                    }
                    else if (serviceController.Status == ServiceControllerStatus.Running)
                    {
                        btnServiceHandle.Text = "Deactivate Service";
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void PrinterChecker()
        {
            _printerStatusTimer.Interval = 2000;
            _printerStatusTimer.Tick += OnPrinterStatusCheck;
            _printerStatusTimer.Start();
        }
        private void OnPrinterStatusCheck(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                _printerUtils.CheckLivePrinters();
                printStatusChange(_printerUtils.GetPrinterStatus());

                logEntries = _jsonLogger.GetLogEntries();

                LoadRecentFiles();
            });

        }

        private void printStatusChange(Dictionary<string, string> _printerStatus)
        {
            if (_printerStatus["status"] == "3" && _printerStatus["isOnline"].ToLower() == "true")
            {
                this.printStatus.BackgroundImage = global::AutoPrint.Properties.Resources.printer_online;
                lblPrintStatus.Text = "Online";
            }
            else if (_printerStatus["status"] == "4" && _printerStatus["isOnline"].ToLower() == "true")
            {
                this.printStatus.BackgroundImage = global::AutoPrint.Properties.Resources.printer_online;
                lblPrintStatus.Text = "Working";
            }
            else
            {
                this.printStatus.BackgroundImage = global::AutoPrint.Properties.Resources.printer_offline;
                lblPrintStatus.Text = "Offline";
            }
        }

        public void setUpJson()
        {
            try
            {
                string _setUp = File.ReadAllText(_autoPrintSetUpJson);
                autoPrintSetup = JsonSerializer.Deserialize<AutoPrintSetup>(_setUp);
                txtFolderPath.Text = autoPrintSetup.HubFolder;
                ChkDirectoryExists(autoPrintSetup.HubFolder);
                ChkDirectoryExists(autoPrintSetup.OutPutFolder);
                ChkDirectoryExists(autoPrintSetup.LogFile);
            }
            catch (Exception ex)
            {
            }
        }


        private void LoadRecentFiles()
        {
            string files = "<html><body>";
            foreach (LogEntry file in logEntries)
            {
                files += $"<p>{file.Info}: {file.Message}  {file.Timestamp}</p>";
            }
            files += "</body></html>";

            UpdateHtmlPanel(files);
        }

        private void UpdateHtmlPanel(string content)
        {
            if (htmlPnlRecentFiles.InvokeRequired)
            {
                htmlPnlRecentFiles.Invoke(new Action(() => htmlPnlRecentFiles.Text = content));
            }
            else
            {
                htmlPnlRecentFiles.Text = content;
            }
        }


        private void btnFolderPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = folderBrowser.SelectedPath;
                }

                if (!File.Exists(folderBrowser.SelectedPath))
                {
                    _fileUtils.WriteAutoPrintSetup(_autoPrintSetUpJson, folderBrowser.SelectedPath, autoPrintSetup.ValidFiles);
                    setUpJson();
                    _jsonLogger = new JsonLogger(autoPrintSetup.LogFile);
                }
            }
        }

        public void ChkDirectoryExists(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception ex)
            { }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AutoPrint SetUp File Path : " + _autoPrintSetUpJson + " ", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnServiceHandle_Click(object sender, EventArgs e)
        {
            try
            {
                using (ServiceController serviceController = new ServiceController(serviceName))
                {
                    if (serviceController.Status == ServiceControllerStatus.Stopped)
                    {
                        serviceController.Start();
                        serviceController.WaitForStatus(ServiceControllerStatus.Running);
                        MessageBox.Show($"Service '{serviceName}' started successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnServiceHandle.Text = "Deactivate Service";
                    }
                    else if (serviceController.Status == ServiceControllerStatus.Running)
                    {
                        serviceController.Stop();
                        serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                        MessageBox.Show($"Service '{serviceName}' stopped successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnServiceHandle.Text = "Active Service";
                    }
                    else
                    {
                        MessageBox.Show($"Service '{serviceName}' is in status: {serviceController.Status}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Administrator rights are required. Please try to run the application as an administrator.");
            }

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.Show();
        }
    }
}
