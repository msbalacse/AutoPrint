using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutoPrintShared.Utils
{
    public class FileUtils
    {
        public FileUtils() { }
        public void setDefaultPath(string setupPath)
        {
            string PATH = "C:\\AutoPrint";
            var setup = new AutoPrintSetup
            {
                HubFolder = PATH + "\\HubFolder",
                OutPutFolder = PATH + "\\OutputFolder",
                LogFile = PATH + "\\Log",
                ValidFiles = ""

            };

            ChkDirectoryExists(PATH);

            if (!File.Exists(setupPath))
            {
                string json = JsonConvert.SerializeObject(setup, Formatting.Indented);
                File.WriteAllText(setupPath, json);
            }
        }

        public AutoPrintSetup CurrentPathSetup(string setupPath)
        {
            string json = File.ReadAllText(setupPath);
            AutoPrintSetup setup = JsonConvert.DeserializeObject<AutoPrintSetup>(json);
            return setup;
        }

        public void WriteAutoPrintSetup(string setupPath, string filepath, string validfiles)
        {
            var setup = new AutoPrintSetup();

            setup.HubFolder = filepath + "\\HubFolder";
            setup.OutPutFolder = filepath + "\\OutputFolder";
            setup.LogFile = filepath + "\\Log";
            setup.ValidFiles = validfiles;


            string json = JsonConvert.SerializeObject(setup, Formatting.Indented);

            File.WriteAllText(setupPath, json);
        }


        public bool ValidFile(string filename, string ValidFiles)
        {
            HashSet<string> validFileNames = new HashSet<string>(ValidFiles.Split(','));

            foreach (var part in validFileNames)
            {
                if (!filename.ToLower().Contains(part.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }

        public string GetParentPath(string path)
        {
            int lastIndex = path.LastIndexOf('\\');
            if (lastIndex != -1)
            {
                return path.Substring(0, lastIndex);
            }
            return "";
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
            catch (Exception ex) { }
        }

        public async Task<bool> WaitForFileReady(string filePath, int maxAttempts = 10, int delayBetweenAttempts = 2000)
        {
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                if (IsFileReady(filePath))
                {
                    return true;
                }

                await Task.Delay(delayBetweenAttempts);
            }
            return false;
        }

        private bool IsFileReady(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
