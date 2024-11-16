using System;
using System.Collections.Generic;
using AutoPrintShared;
using AutoPrintShared.Utils;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using System.Threading.Tasks;

namespace AutoprintService
{
    partial class MainService : ServiceBase
    {
        public event Action<List<string>> OnDataUpdated;
        private List<string> _dataList = new List<string>();

        //public ServiceError _serviceError = new ServiceError();
        public AutoPrintSetup _autoPrintSetup = new AutoPrintSetup();

        public FileUtils _fileUtils = new FileUtils();
        public PrinterUtils _printerUtils = new PrinterUtils();
        public CommonUtils _commonUtils = null;

        public PdfPrinter _printer = null;

        private Timer timer = new Timer();
        private FileSystemWatcher _watcher;

        private bool LastPrinterStatus = false;

        string _autoPrintSetUpJson = "C:\\AutoPrint\\Setup\\autoprint_setup.json";

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string SetUpDir = _fileUtils.GetParentPath(_autoPrintSetUpJson);
            _fileUtils.ChkDirectoryExists(SetUpDir);
            _fileUtils.setDefaultPath(_autoPrintSetUpJson);
            _autoPrintSetup = _fileUtils.CurrentPathSetup(_autoPrintSetUpJson);

            _fileUtils.ChkDirectoryExists(_autoPrintSetup.HubFolder);
            _fileUtils.ChkDirectoryExists(_autoPrintSetup.LogFile);
            _fileUtils.ChkDirectoryExists(_autoPrintSetup.OutPutFolder);

            _commonUtils = new CommonUtils(_autoPrintSetup.LogFile);
            _printer = new PdfPrinter(_autoPrintSetup);

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 5000;
            timer.Enabled = true;
            //_serviceError.ErrorActivity("service started");
            StartWatching();
        }

        private async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _autoPrintSetup = _fileUtils.CurrentPathSetup(_autoPrintSetUpJson);
            _printer = new PdfPrinter(_autoPrintSetup);
            _watcher.Path = _autoPrintSetup.HubFolder;
            if (LastPrinterStatus == false && _printerUtils.CheckLivePrinters())
            {
                await ProcessExistingFiles();
                //_commonUtils.LogUnsupportedFileType("Printer status changeed");
            }
            LastPrinterStatus = _printerUtils.CheckLivePrinters();
        }

        protected override void OnStop()
        {
            //_serviceError.ErrorActivity("service stop");
        }

        private void StartWatching()
        {

            _watcher = new FileSystemWatcher
            {
                Path = _autoPrintSetup.HubFolder,
                EnableRaisingEvents = true,
                InternalBufferSize = 4096,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                Filter = "*.*"
            };
            _watcher.Created += OnFileCreated;

        }

        private async void OnFileCreated(object source, FileSystemEventArgs e)
        {
            string fullPath = e.FullPath;
            bool fileReady = await _fileUtils.WaitForFileReady(fullPath);

            if (fileReady)
            {
                PdfValidation(fullPath);
            }
            else
            {
                _commonUtils.LogFileNotAccessible(fullPath);
            }

        }

        private async Task ProcessExistingFiles()
        {
            try
            {
                var existingFiles = Directory.GetFiles(_autoPrintSetup.HubFolder, "*.*");
                foreach (var file in existingFiles)
                {
                    await Task.Run(() => PdfValidation(file));
                }
            }
            catch (Exception ex)
            {
            }

        }

        private async void PdfValidation(string fullPath)
        {
            if (!_commonUtils.IsSupportedFileType(fullPath))
            {
                _commonUtils.LogUnsupportedFileType(fullPath);
                return;
            }

            if (!_printerUtils.CheckLivePrinters())
            {
                return;
            }

            if (!_fileUtils.ValidFile(fullPath, _autoPrintSetup.ValidFiles))
            {
                _commonUtils.LogUnValidFiles(fullPath);
                return;
            }

            await _printer.PrintPdf(fullPath);
        }

    }
}
