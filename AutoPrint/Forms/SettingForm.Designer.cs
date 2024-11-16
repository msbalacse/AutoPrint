namespace AutoPrint.Forms
{
    partial class SettingForm
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
            this.btnSettingSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFileNameInc = new System.Windows.Forms.Label();
            this.txtFileNameInc = new MetroFramework.Controls.MetroTextBox();
            this.lblFileNameIncMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSettingSave
            // 
            this.btnSettingSave.Location = new System.Drawing.Point(123, 180);
            this.btnSettingSave.Name = "btnSettingSave";
            this.btnSettingSave.Size = new System.Drawing.Size(75, 23);
            this.btnSettingSave.TabIndex = 0;
            this.btnSettingSave.Text = "Save";
            this.btnSettingSave.UseVisualStyleBackColor = true;
            this.btnSettingSave.Click += new System.EventHandler(this.btnSettingSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFileNameInc
            // 
            this.lblFileNameInc.AutoSize = true;
            this.lblFileNameInc.Location = new System.Drawing.Point(64, 83);
            this.lblFileNameInc.Name = "lblFileNameInc";
            this.lblFileNameInc.Size = new System.Drawing.Size(52, 26);
            this.lblFileNameInc.TabIndex = 2;
            this.lblFileNameInc.Text = "Filename \r\n(Include)";
            // 
            // txtFileNameInc
            // 
            // 
            // 
            // 
            this.txtFileNameInc.CustomButton.Image = null;
            this.txtFileNameInc.CustomButton.Location = new System.Drawing.Point(212, 1);
            this.txtFileNameInc.CustomButton.Name = "";
            this.txtFileNameInc.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFileNameInc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFileNameInc.CustomButton.TabIndex = 1;
            this.txtFileNameInc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFileNameInc.CustomButton.UseSelectable = true;
            this.txtFileNameInc.CustomButton.Visible = false;
            this.txtFileNameInc.Lines = new string[0];
            this.txtFileNameInc.Location = new System.Drawing.Point(142, 83);
            this.txtFileNameInc.MaxLength = 32767;
            this.txtFileNameInc.Name = "txtFileNameInc";
            this.txtFileNameInc.PasswordChar = '\0';
            this.txtFileNameInc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFileNameInc.SelectedText = "";
            this.txtFileNameInc.SelectionLength = 0;
            this.txtFileNameInc.SelectionStart = 0;
            this.txtFileNameInc.ShortcutsEnabled = true;
            this.txtFileNameInc.Size = new System.Drawing.Size(234, 23);
            this.txtFileNameInc.TabIndex = 3;
            this.txtFileNameInc.UseSelectable = true;
            this.txtFileNameInc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFileNameInc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblFileNameIncMsg
            // 
            this.lblFileNameIncMsg.AutoSize = true;
            this.lblFileNameIncMsg.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblFileNameIncMsg.Location = new System.Drawing.Point(141, 111);
            this.lblFileNameIncMsg.Name = "lblFileNameIncMsg";
            this.lblFileNameIncMsg.Size = new System.Drawing.Size(236, 26);
            this.lblFileNameIncMsg.TabIndex = 4;
            this.lblFileNameIncMsg.Text = "(Must be separated by commas if more than one \r\ncondition.)";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 235);
            this.Controls.Add(this.lblFileNameIncMsg);
            this.Controls.Add(this.txtFileNameInc);
            this.Controls.Add(this.lblFileNameInc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSettingSave);
            this.Name = "SettingForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettingSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFileNameInc;
        private MetroFramework.Controls.MetroTextBox txtFileNameInc;
        private System.Windows.Forms.Label lblFileNameIncMsg;
    }
}