using MetroFramework.Forms;
using System;
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
    public partial class NotificationForm : MetroForm
    {
        public NotificationForm(string title, string message)
        {
            this.ControlBox = false;
            Point formLocation = this.Location;
            InitializeComponent();
            this.Text = ""; // Set form title
            this.labelMessage.Text = message +" " + formLocation.X.ToString() + " " + formLocation.Y.ToString(); // Set message text
        }

        // Method to show the notification in a specific position
        public void ShowAt(int x, int y)
        {
            this.Location = new System.Drawing.Point(x, y);
            this.Show();
            //this.Hide(); // Automatically hide after a few seconds
            Timer timer = new Timer();
            timer.Interval = 3000; // Display for 3 seconds
            timer.Tick += (s, e) =>
            {
                this.Hide();
                timer.Stop();
            };
            timer.Start();
        }

    }
}
