using System.Windows.Forms;

namespace Wdbexec
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.execquery = new System.Windows.Forms.Button();
            this.lblTableContext = new System.Windows.Forms.Label();
            this.btnApplyGridChangesToAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRunOnAllDatabases = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.databname = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnConnectAll = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.execquery);
            this.panel1.Controls.Add(this.lblTableContext);
            this.panel1.Controls.Add(this.btnApplyGridChangesToAll);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnRunOnAllDatabases);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1226, 404);
            this.panel1.TabIndex = 0;
            // 
            // execquery
            // 
            this.execquery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.execquery.Location = new System.Drawing.Point(959, 352);
            this.execquery.Name = "execquery";
            this.execquery.Size = new System.Drawing.Size(112, 23);
            this.execquery.TabIndex = 7;
            this.execquery.Text = "Execute Query";
            this.execquery.UseVisualStyleBackColor = true;
            this.execquery.Click += new System.EventHandler(this.execquery_Click);
            // 
            // lblTableContext
            // 
            this.lblTableContext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTableContext.AutoSize = true;
            this.lblTableContext.Location = new System.Drawing.Point(521, 380);
            this.lblTableContext.Name = "lblTableContext";
            this.lblTableContext.Size = new System.Drawing.Size(34, 13);
            this.lblTableContext.TabIndex = 6;
            this.lblTableContext.Text = "---------";
            // 
            // btnApplyGridChangesToAll
            // 
            this.btnApplyGridChangesToAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyGridChangesToAll.Location = new System.Drawing.Point(1077, 378);
            this.btnApplyGridChangesToAll.Name = "btnApplyGridChangesToAll";
            this.btnApplyGridChangesToAll.Size = new System.Drawing.Size(137, 23);
            this.btnApplyGridChangesToAll.TabIndex = 5;
            this.btnApplyGridChangesToAll.Text = "Exec Table For All";
            this.btnApplyGridChangesToAll.UseVisualStyleBackColor = true;
            this.btnApplyGridChangesToAll.Click += new System.EventHandler(this.btnApplyGridChangesToAll_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(959, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Excute Table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRunOnAllDatabases
            // 
            this.btnRunOnAllDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunOnAllDatabases.Location = new System.Drawing.Point(1077, 352);
            this.btnRunOnAllDatabases.Name = "btnRunOnAllDatabases";
            this.btnRunOnAllDatabases.Size = new System.Drawing.Size(137, 23);
            this.btnRunOnAllDatabases.TabIndex = 3;
            this.btnRunOnAllDatabases.Text = "Exec Query For All";
            this.btnRunOnAllDatabases.UseVisualStyleBackColor = true;
            this.btnRunOnAllDatabases.Click += new System.EventHandler(this.btnRunOnAllDatabases_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(521, 6);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(693, 343);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar2);
            this.panel2.Controls.Add(this.databname);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.btnConnectAll);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 380);
            this.panel2.TabIndex = 1;
            // 
            // databname
            // 
            this.databname.Location = new System.Drawing.Point(12, 8);
            this.databname.Name = "databname";
            this.databname.Size = new System.Drawing.Size(286, 20);
            this.databname.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 335);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(395, 10);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(304, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(184, 196);
            this.treeView1.TabIndex = 2;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 222);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(476, 99);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnConnectAll
            // 
            this.btnConnectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectAll.Location = new System.Drawing.Point(413, 327);
            this.btnConnectAll.Name = "btnConnectAll";
            this.btnConnectAll.Size = new System.Drawing.Size(75, 23);
            this.btnConnectAll.TabIndex = 1;
            this.btnConnectAll.Text = "Start";
            this.btnConnectAll.UseVisualStyleBackColor = true;
            this.btnConnectAll.Click += new System.EventHandler(this.btnConnectAll_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 34);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(286, 168);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 404);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1226, 243);
            this.dataGridView1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.addToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1226, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serversToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.addToolStripMenuItem.Text = "Config";
            // 
            // serversToolStripMenuItem
            // 
            this.serversToolStripMenuItem.Name = "serversToolStripMenuItem";
            this.serversToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serversToolStripMenuItem.Text = "Servers";
            this.serversToolStripMenuItem.Click += new System.EventHandler(this.serversToolStripMenuItem_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(413, 351);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(75, 10);
            this.progressBar2.TabIndex = 5;
            this.progressBar2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 647);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "WPolyQuery V 1.0";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnConnectAll;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnRunOnAllDatabases;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnApplyGridChangesToAll;
        private System.Windows.Forms.Label lblTableContext;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox databname;
        private Button execquery;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem serversToolStripMenuItem;
        private ProgressBar progressBar2;
    }
}

