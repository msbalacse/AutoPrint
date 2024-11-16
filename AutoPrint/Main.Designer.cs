namespace AutoPrint
{
    partial class AutoPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoPrint));
            this.btnFolderPath = new MetroFramework.Controls.MetroButton();
            this.txtFolderPath = new MetroFramework.Controls.MetroTextBox();
            this.htmlPnlRecentFiles = new MetroFramework.Drawing.Html.HtmlPanel();
            this.lblRecentFiles = new MetroFramework.Controls.MetroLabel();
            this.printStatus = new System.Windows.Forms.Panel();
            this.lblPrintStatus = new MetroFramework.Controls.MetroLabel();
            this.btnServiceHandle = new MetroFramework.Controls.MetroButton();
            this.btnSetting = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnFolderPath
            // 
            this.btnFolderPath.Location = new System.Drawing.Point(26, 64);
            this.btnFolderPath.Name = "btnFolderPath";
            this.btnFolderPath.Size = new System.Drawing.Size(75, 23);
            this.btnFolderPath.TabIndex = 2;
            this.btnFolderPath.Text = "Folder Path";
            this.btnFolderPath.UseSelectable = true;
            this.btnFolderPath.Click += new System.EventHandler(this.btnFolderPath_Click);
            // 
            // txtFolderPath
            // 
            // 
            // 
            // 
            this.txtFolderPath.CustomButton.Image = null;
            this.txtFolderPath.CustomButton.Location = new System.Drawing.Point(371, 1);
            this.txtFolderPath.CustomButton.Name = "";
            this.txtFolderPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFolderPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFolderPath.CustomButton.TabIndex = 1;
            this.txtFolderPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFolderPath.CustomButton.UseSelectable = true;
            this.txtFolderPath.CustomButton.Visible = false;
            this.txtFolderPath.Icon = ((System.Drawing.Image)(resources.GetObject("txtFolderPath.Icon")));
            this.txtFolderPath.Lines = new string[] {
        "Pick a path"};
            this.txtFolderPath.Location = new System.Drawing.Point(107, 64);
            this.txtFolderPath.MaxLength = 32767;
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.PasswordChar = '\0';
            this.txtFolderPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFolderPath.SelectedText = "";
            this.txtFolderPath.SelectionLength = 0;
            this.txtFolderPath.SelectionStart = 0;
            this.txtFolderPath.ShortcutsEnabled = true;
            this.txtFolderPath.Size = new System.Drawing.Size(393, 23);
            this.txtFolderPath.TabIndex = 3;
            this.txtFolderPath.Text = "Pick a path";
            this.txtFolderPath.UseSelectable = true;
            this.txtFolderPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFolderPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // htmlPnlRecentFiles
            // 
            this.htmlPnlRecentFiles.AutoScroll = true;
            this.htmlPnlRecentFiles.AutoScrollMinSize = new System.Drawing.Size(669, 0);
            this.htmlPnlRecentFiles.BackColor = System.Drawing.SystemColors.Window;
            this.htmlPnlRecentFiles.Location = new System.Drawing.Point(26, 148);
            this.htmlPnlRecentFiles.Name = "htmlPnlRecentFiles";
            this.htmlPnlRecentFiles.Padding = new System.Windows.Forms.Padding(10);
            this.htmlPnlRecentFiles.Size = new System.Drawing.Size(669, 331);
            this.htmlPnlRecentFiles.TabIndex = 8;
            // 
            // lblRecentFiles
            // 
            this.lblRecentFiles.AutoSize = true;
            this.lblRecentFiles.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRecentFiles.Location = new System.Drawing.Point(26, 120);
            this.lblRecentFiles.Name = "lblRecentFiles";
            this.lblRecentFiles.Size = new System.Drawing.Size(100, 25);
            this.lblRecentFiles.TabIndex = 9;
            this.lblRecentFiles.Text = "Recent Files";
            // 
            // printStatus
            // 
            this.printStatus.BackgroundImage = global::AutoPrint.Properties.Resources.printer_online;
            this.printStatus.Location = new System.Drawing.Point(135, 26);
            this.printStatus.Name = "printStatus";
            this.printStatus.Size = new System.Drawing.Size(24, 24);
            this.printStatus.TabIndex = 12;
            // 
            // lblPrintStatus
            // 
            this.lblPrintStatus.AutoSize = true;
            this.lblPrintStatus.Location = new System.Drawing.Point(162, 28);
            this.lblPrintStatus.Name = "lblPrintStatus";
            this.lblPrintStatus.Size = new System.Drawing.Size(44, 19);
            this.lblPrintStatus.TabIndex = 13;
            this.lblPrintStatus.Text = "online";
            // 
            // btnServiceHandle
            // 
            this.btnServiceHandle.Location = new System.Drawing.Point(510, 64);
            this.btnServiceHandle.Name = "btnServiceHandle";
            this.btnServiceHandle.Size = new System.Drawing.Size(116, 23);
            this.btnServiceHandle.TabIndex = 14;
            this.btnServiceHandle.Text = "Active Service";
            this.btnServiceHandle.UseSelectable = true;
            this.btnServiceHandle.Click += new System.EventHandler(this.btnServiceHandle_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImage = global::AutoPrint.Properties.Resources.setting_icon;
            this.btnSetting.Location = new System.Drawing.Point(641, 65);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(24, 24);
            this.btnSetting.TabIndex = 16;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackgroundImage = global::AutoPrint.Properties.Resources.help_icon;
            this.btnHelp.Location = new System.Drawing.Point(671, 65);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(24, 24);
            this.btnHelp.TabIndex = 17;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // AutoPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 512);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnServiceHandle);
            this.Controls.Add(this.lblPrintStatus);
            this.Controls.Add(this.printStatus);
            this.Controls.Add(this.lblRecentFiles);
            this.Controls.Add(this.htmlPnlRecentFiles);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.btnFolderPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto Print";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnFolderPath;
        private MetroFramework.Controls.MetroTextBox txtFolderPath;
        private MetroFramework.Drawing.Html.HtmlPanel htmlPnlRecentFiles;
        private MetroFramework.Controls.MetroLabel lblRecentFiles;
        private System.Windows.Forms.Panel printStatus;
        private MetroFramework.Controls.MetroLabel lblPrintStatus;
        private MetroFramework.Controls.MetroButton btnServiceHandle;
        private System.Windows.Forms.Panel btnSetting;
        private System.Windows.Forms.Panel btnHelp;
    }
}

