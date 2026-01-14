using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wdbexec
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Text = "About WPolyQuery V 1.0";
            this.Width = 500;
            this.Height = 300;
            this.StartPosition = FormStartPosition.CenterParent;

            Label infoLabel = new Label();
            infoLabel.Text =
                "WPolyQuery\n\n" +
                "A Windows application to run SQL queries across multiple\n" +
                "databases on different servers efficiently.\n\n" +
                "Created by: W. Ouadfeul\n" +
                "Email: walid.ouadfeul@gmail.com\n" +
                "© EGSA-Alger";
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            infoLabel.Dock = DockStyle.Top;
            infoLabel.Height = 180;
            infoLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            Button openPdfButton = new Button();
            openPdfButton.Text = "Open User Guide (PDF)";
            openPdfButton.Dock = DockStyle.Bottom;
            openPdfButton.Height = 40;
            openPdfButton.Click += OpenPdfButton_Click;

            this.Controls.Add(infoLabel);
            this.Controls.Add(openPdfButton);
        }
        private void OpenPdfButton_Click(object sender, EventArgs e)
        {
            string pdfPath = ConfigurationManager.AppSettings["UserGuidePdfPath"];
            if (!string.IsNullOrEmpty(pdfPath) && System.IO.File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("User guide PDF not found. Please check the path in App.config.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
