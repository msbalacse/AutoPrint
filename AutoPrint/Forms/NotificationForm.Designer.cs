namespace AutoPrint.Forms
{
    partial class NotificationForm
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.lblPrinterStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(104, 26);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(37, 13);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Online";
            // 
            // lblPrinterStatus
            // 
            this.lblPrinterStatus.AutoSize = true;
            this.lblPrinterStatus.Location = new System.Drawing.Point(23, 25);
            this.lblPrinterStatus.Name = "lblPrinterStatus";
            this.lblPrinterStatus.Size = new System.Drawing.Size(76, 13);
            this.lblPrinterStatus.TabIndex = 1;
            this.lblPrinterStatus.Text = "Printer Status :";
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 66);
            this.Controls.Add(this.lblPrinterStatus);
            this.Controls.Add(this.labelMessage);
            this.Name = "NotificationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label lblPrinterStatus;
    }
}