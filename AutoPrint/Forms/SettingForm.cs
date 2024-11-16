using AutoPrintShared;
using AutoPrintShared.Utils;
using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPrint.Forms
{
    public partial class SettingForm : MetroForm
    {

        private string _autoPrintSetUpJson = "C:\\AutoPrint\\Setup\\autoprint_setup.json";
        private AutoPrintSetup _autoPrintSetup = new AutoPrintSetup();
        private FileUtils _fileUtils = new FileUtils();
        public SettingForm()
        {
            this.ControlBox = false;
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            _autoPrintSetup = _fileUtils.CurrentPathSetup(_autoPrintSetUpJson);
            txtFileNameInc.Text = _autoPrintSetup.ValidFiles;
        }

        private void btnSettingSave_Click(object sender, EventArgs e)
        {

            var setup = new AutoPrintSetup();

            setup.HubFolder = _autoPrintSetup.HubFolder;
            setup.OutPutFolder = _autoPrintSetup.OutPutFolder;
            setup.LogFile = _autoPrintSetup.LogFile;
            setup.ValidFiles = txtFileNameInc.Text;

            string json = JsonConvert.SerializeObject(setup, Formatting.Indented);

            File.WriteAllText(_autoPrintSetUpJson, json);

            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtFileNameInc.Text = "";
            this.Close();
        }
    }
}
