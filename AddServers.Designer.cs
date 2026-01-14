using System.Drawing;
using System.Windows.Forms;
using System;

namespace Wdbexec
{
    partial class AddServers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddServers));
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAddConnection = new System.Windows.Forms.Button();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btndelconnection = new System.Windows.Forms.Button();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(208, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(252, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(439, 20);
            this.txtName.TabIndex = 1;
            // 
            // labelServer
            // 
            this.labelServer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(149, 33);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(97, 13);
            this.labelServer.TabIndex = 2;
            this.labelServer.Text = "Server Name or IP:";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(252, 33);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(439, 20);
            this.txtServer.TabIndex = 3;
            // 
            // labelDatabase
            // 
            this.labelDatabase.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Location = new System.Drawing.Point(159, 53);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(87, 13);
            this.labelDatabase.TabIndex = 4;
            this.labelDatabase.Text = "Database Name:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.Location = new System.Drawing.Point(252, 53);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(439, 20);
            this.txtDatabase.TabIndex = 5;
            // 
            // labelUser
            // 
            this.labelUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(214, 73);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(32, 13);
            this.labelUser.TabIndex = 6;
            this.labelUser.Text = "User:";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(252, 73);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(439, 20);
            this.txtUser.TabIndex = 7;
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(190, 93);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(252, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(439, 20);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnAddConnection
            // 
            this.btnAddConnection.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddConnection.AutoSize = true;
            this.btnAddConnection.Location = new System.Drawing.Point(125, 169);
            this.btnAddConnection.Name = "btnAddConnection";
            this.btnAddConnection.Size = new System.Drawing.Size(121, 23);
            this.btnAddConnection.TabIndex = 10;
            this.btnAddConnection.Text = "Add";
            this.btnAddConnection.Click += new System.EventHandler(this.btnAddConnection_Click);
            // 
            // layout
            // 
            this.layout.AutoSize = true;
            this.layout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layout.ColumnCount = 2;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.layout.Controls.Add(this.labelName, 0, 0);
            this.layout.Controls.Add(this.txtName, 1, 0);
            this.layout.Controls.Add(this.labelServer, 0, 1);
            this.layout.Controls.Add(this.txtServer, 1, 1);
            this.layout.Controls.Add(this.labelDatabase, 0, 2);
            this.layout.Controls.Add(this.txtDatabase, 1, 2);
            this.layout.Controls.Add(this.labelUser, 0, 3);
            this.layout.Controls.Add(this.txtUser, 1, 3);
            this.layout.Controls.Add(this.labelPassword, 0, 4);
            this.layout.Controls.Add(this.txtPassword, 1, 4);
            this.layout.Controls.Add(this.dataGridView2, 1, 5);
            this.layout.Controls.Add(this.btnAddConnection, 0, 5);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.Padding = new System.Windows.Forms.Padding(10);
            this.layout.RowCount = 6;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.Size = new System.Drawing.Size(704, 261);
            this.layout.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(252, 113);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView2.Size = new System.Drawing.Size(439, 135);
            this.dataGridView2.TabIndex = 11;
            // 
            // btndelconnection
            // 
            this.btndelconnection.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btndelconnection.AutoSize = true;
            this.btndelconnection.Location = new System.Drawing.Point(125, 113);
            this.btndelconnection.Name = "btndelconnection";
            this.btndelconnection.Size = new System.Drawing.Size(121, 23);
            this.btndelconnection.TabIndex = 10;
            this.btndelconnection.Text = "Del";
            this.btndelconnection.Click += new System.EventHandler(this.btndelconnection_Click);
            // 
            // AddServers
            // 
            this.ClientSize = new System.Drawing.Size(704, 261);
            this.Controls.Add(this.btndelconnection);
            this.Controls.Add(this.layout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(622, 300);
            this.Name = "AddServers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config Servers";
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAddConnection;
        private TableLayoutPanel layout;
       
        private DataGridView dataGridView2;
        private Button btndelconnection;
    }
}
