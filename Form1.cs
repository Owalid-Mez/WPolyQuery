using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Wdbexec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.Columns.Add("Server", 150);
            listView1.Columns.Add("Status", 100);
            listView1.View = View.Details;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick; // ✅ Fixed
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick; // ✅ Fixed
            richTextBox2.TextChanged += (s, e) => HighlightSql(richTextBox2);
        }
        private readonly string[] sqlKeywords = new string[]
        {
            "SELECT", "FROM", "WHERE", "UPDATE", "DELETE", "INSERT", "INTO", "VALUES",
            "SET", "JOIN", "ON", "AND", "OR", "NOT", "NULL", "IS", "AS", "IN",
            "CREATE", "TABLE", "DROP", "ALTER", "VIEW", "TRUNCATE", "DISTINCT", "TOP"
        };
        private void HighlightSql(RichTextBox rtb)
        {
            int selectionStart = rtb.SelectionStart;
            int selectionLength = rtb.SelectionLength;

            rtb.SuspendLayout(); // Prevent flicker
            rtb.SelectAll();
            rtb.SelectionColor = Color.Black; // Reset

            foreach (string keyword in sqlKeywords)
            {
                Regex regex = new Regex(@"\b" + keyword + @"\b", RegexOptions.IgnoreCase);
                foreach (Match m in regex.Matches(rtb.Text))
                {
                    rtb.Select(m.Index, m.Length);
                    rtb.SelectionColor = Color.Blue;
                }
            }

            // Strings in single quotes
            Regex stringRegex = new Regex("'[^']*'");
            foreach (Match m in stringRegex.Matches(rtb.Text))
            {
                rtb.Select(m.Index, m.Length);
                rtb.SelectionColor = Color.Brown;
            }

            // Single-line comments --
            Regex commentRegex = new Regex("--[^\n]*");
            foreach (Match m in commentRegex.Matches(rtb.Text))
            {
                rtb.Select(m.Index, m.Length);
                rtb.SelectionColor = Color.Green;
            }

            // Restore selection
            rtb.SelectionStart = selectionStart;
            rtb.SelectionLength = selectionLength;
            rtb.SelectionColor = Color.Black;
            rtb.ResumeLayout();
        }
        private string lastUsedTableName = null;
        private async void btnConnectAll_Click(object sender, EventArgs e)
        {
            btnConnectAll.Enabled = false;
            progressBar2.Visible = true;
            listView1.Items.Clear();
            richTextBox1.Clear();

            var connections = ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>()
                .Where(c => !string.IsNullOrWhiteSpace(c.Name) && c.Name != "LocalSqlServer")
                .ToList();

            int total = connections.Count;
            if (total == 0)
            {
                MessageBox.Show("No connections found.");
                return;
            }

            progressBar2.Minimum = 0;
            progressBar2.Maximum = total + 1;
            progressBar2.Value = 1;
            progressBar2.Step = 1;
            
            foreach (var connStrSetting in connections)
            {
                string name = connStrSetting.Name;
                string connStr = connStrSetting.ConnectionString;

                await Task.Run(() =>
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            conn.Open();
                            Invoke((MethodInvoker)(() =>
                            {
                                listView1.Items.Add(new ListViewItem(new[] { name, "Connected" }));
                                AppendColoredText($"[SUCCESS] Connected to {name}\n", Color.Green);
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            listView1.Items.Add(new ListViewItem(new[] { name, "Failed" }));
                            AppendColoredText($"[ERROR] Failed to connect to {name}: {ex.Message}\n", Color.Red);
                        }));
                    }
                });

                progressBar2.Value += 1;
                await Task.Delay(50); // Give the UI thread time to update
            }
           
           btnConnectAll.Enabled = true;
            progressBar2.Visible = false;
            
        }

        private void AppendColoredText(string text, Color labelColor)
        {
            int endOfLabel = text.IndexOf(']') + 1;

            if (endOfLabel <= 0 || endOfLabel >= text.Length)
            {
                // Fallback if no label is found
                richTextBox1.Invoke(() =>
                {
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    richTextBox1.SelectionColor = richTextBox1.ForeColor;
                    richTextBox1.AppendText(text);
                    richTextBox1.ScrollToCaret();
                });
                return;
            }

            string label = text.Substring(0, endOfLabel);   // e.g., "[ERROR]"
            string message = text.Substring(endOfLabel);    // the rest

            richTextBox1.Invoke(() =>
            {
                // Append label in color
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.SelectionColor = labelColor;
                richTextBox1.AppendText(label);

                // Append message in default color
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
                richTextBox1.AppendText(message);

                // Auto-scroll
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.ScrollToCaret();
            });
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            string serverName = listView1.SelectedItems[0].Text;
            string connStr = ConfigurationManager.ConnectionStrings[serverName]?.ConnectionString;

            if (string.IsNullOrEmpty(connStr))
            {
                MessageBox.Show("Connection string not found.");
                return;
            }

            treeView1.Nodes.Clear();
            TreeNode serverNode = new TreeNode(serverName);
            treeView1.Nodes.Add(serverNode);

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query;
                    if (!string.IsNullOrWhiteSpace(databname.Text))
                    {
                        query = "SELECT name FROM sys.databases WHERE database_id > 4 AND name LIKE @dbname";
                    }
                    else
                    {
                        query = "SELECT name FROM sys.databases WHERE database_id > 4";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(databname.Text))
                        {
                            cmd.Parameters.AddWithValue("@dbname", $"%{databname.Text}%");
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string dbName = reader.GetString(0);
                                TreeNode dbNode = new TreeNode(dbName);
                                dbNode.Nodes.Add(new TreeNode("Loading..."));
                                serverNode.Nodes.Add(dbNode);
                            }
                        }
                    }
                }

                serverNode.Expand();
                AppendColoredText($"[INFO] Loaded databases for {serverName}\n",Color.Aqua);
            }
            catch (Exception ex)
            {
                AppendColoredText($"[ERROR] Failed to load databases: {ex.Message}\n",Color.Red);
            }

        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode.Parent == null || selectedNode.Parent.Parent != null)
                return;

            string serverName = selectedNode.Parent.Text;
            string databaseName = selectedNode.Text;

            if (selectedNode.Nodes.Count > 0 && selectedNode.Nodes[0].Text != "Loading...")
                return;

            selectedNode.Nodes.Clear();

            string baseConnStr = ConfigurationManager.ConnectionStrings[serverName]?.ConnectionString;
            if (string.IsNullOrEmpty(baseConnStr))
                return;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(baseConnStr)
            {
                InitialCatalog = databaseName
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(builder.ToString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string schema = reader.GetString(0);
                        string table = reader.GetString(1);
                        selectedNode.Nodes.Add(new TreeNode($"{schema}.{table}"));
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                selectedNode.Nodes.Add(new TreeNode("[Error loading tables]"));
                AppendColoredText($"[ERROR] {databaseName}: {ex.Message}\n",Color.Red);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) // ✅ Updated
        {
            TreeNode clickedNode = e.Node;

            // ✅ If it's a Table (grandparent = server, parent = database)
            if (clickedNode.Parent != null && clickedNode.Parent.Parent != null)
            {
                string tableName = clickedNode.Text;

                int selectionIndex = richTextBox2.SelectionStart;
                richTextBox2.Text = richTextBox2.Text.Insert(selectionIndex, tableName);
                richTextBox2.SelectionStart = selectionIndex + tableName.Length;
                richTextBox2.Focus();
                return;
            }

            // ✅ If it's a Database (parent = server)
            
        }

        private async void btnRunOnAllDatabases_Click(object sender, EventArgs e)
        {
            btnRunOnAllDatabases.Enabled = false;
            string query = richTextBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a SQL query to execute.");
                btnRunOnAllDatabases.Enabled = true;
                return;
            }

            bool isSelect = query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase);
            DataTable mergedResult = new DataTable();
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            var targets = new List<(string server, string connStr, string database)>();

            foreach (ConnectionStringSettings connStrSetting in ConfigurationManager.ConnectionStrings)
            {
                if (connStrSetting.Name == "LocalSqlServer")
                    continue;

                string serverName = connStrSetting.Name;
                string baseConnStr = connStrSetting.ConnectionString;

                try
                {
                    using SqlConnection conn = new SqlConnection(baseConnStr);
                    await conn.OpenAsync();

                    string dbquery = string.IsNullOrWhiteSpace(databname.Text)
                        ? "SELECT name FROM sys.databases WHERE database_id > 4"
                        : "SELECT name FROM sys.databases WHERE database_id > 4 AND name LIKE @dbname";

                    using SqlCommand cmd = new SqlCommand(dbquery, conn);
                    if (!string.IsNullOrWhiteSpace(databname.Text))
                    {
                        cmd.Parameters.AddWithValue("@dbname", $"%{databname.Text}%");
                    }

                    using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        string dbName = reader.GetString(0);
                        targets.Add((serverName, baseConnStr, dbName));
                    }
                }
                catch (Exception ex)
                {
                    AppendColoredText($"[ERROR] Failed to get databases from {connStrSetting.Name}: {ex.Message}\n", Color.Red);
                }
            }

            int total = targets.Count;
            if (total == 0)
            {
                progressBar1.Visible = false;
                MessageBox.Show("No databases found.");
                btnRunOnAllDatabases.Enabled = true;
                return;
            }

            progressBar1.Maximum = total;

            await Task.Run(async () =>
            {
                int completed = 0;

                foreach (var target in targets)
                {
                    try
                    {
                        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(target.connStr)
                        {
                            InitialCatalog = target.database
                        };

                        using SqlConnection conn = new SqlConnection(builder.ToString());
                        await conn.OpenAsync();

                        SqlCommand cmd = new SqlCommand(query, conn);

                        if (isSelect)
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable resultTable = new DataTable();
                            adapter.Fill(resultTable);

                            resultTable.Columns.Add("Server", typeof(string));
                            resultTable.Columns.Add("Database", typeof(string));

                            foreach (DataRow row in resultTable.Rows)
                            {
                                row["Server"] = target.server;
                                row["Database"] = target.database;
                            }

                            lock (mergedResult)
                            {
                                mergedResult.Merge(resultTable, true, MissingSchemaAction.Add);
                            }

                            Invoke(() => AppendColoredText($"[OK] SELECT on {target.server}.{target.database} - {resultTable.Rows.Count} rows\n", Color.Blue));
                        }
                        else
                        {
                            int rows = await cmd.ExecuteNonQueryAsync();
                            Invoke(() => AppendColoredText($"[OK] {rows} rows affected on {target.server}.{target.database}\n", Color.Blue));
                        }
                    }
                    catch (Exception ex)
                    {
                        Invoke(() => AppendColoredText($"[ERROR] {target.server}.{target.database}: {ex.Message}\n", Color.Red));
                    }

                    completed++;
                    Invoke(() => progressBar1.Value = completed);
                   
                }
            });

            progressBar1.Visible = false;

            if (isSelect && mergedResult.Rows.Count > 0)
            {
                dataGridView1.Invoke(() => dataGridView1.DataSource = mergedResult);
            }

            MessageBox.Show("Query executed on all databases.");
            btnRunOnAllDatabases.Enabled = true;
        }








        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ExecuteQueryOnSelectedNode();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Tag is Tuple<SqlConnection, SqlDataAdapter, DataTable> data)
            {
                try
                {
                    int rowsUpdated = data.Item2.Update(data.Item3);
                    AppendColoredText($"[INFO] {rowsUpdated} changes saved to the database.\n", Color.Aqua);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppendColoredText($"[ERROR] Save failed: {ex.Message}\n", Color.Red);
                }
            }
            else
            {
                MessageBox.Show("No editable data loaded.");
            }
        }

        private async void btnApplyGridChangesToAll_Click(object sender, EventArgs e)
        {
            btnApplyGridChangesToAll.Enabled = false;

            if (dataGridView1.DataSource is not DataTable dataTable || string.IsNullOrEmpty(lastUsedTableName))
            {
                MessageBox.Show("No table loaded or changes available to update.");
                btnApplyGridChangesToAll.Enabled = true;
                return;
            }

            progressBar1.Value = 0;
            progressBar1.Visible = true;

            var targets = new List<(string server, string connectionString, string db)>();

            foreach (ConnectionStringSettings connStrSetting in ConfigurationManager.ConnectionStrings)
            {
                if (connStrSetting.Name == "LocalSqlServer")
                    continue;

                string serverName = connStrSetting.Name;
                string baseConnStr = connStrSetting.ConnectionString;

                try
                {
                    using SqlConnection conn = new SqlConnection(baseConnStr);
                    await conn.OpenAsync();

                    using SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE database_id > 4", conn);
                    using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string dbName = reader.GetString(0);
                        targets.Add((serverName, baseConnStr, dbName));
                    }
                }
                catch (Exception ex)
                {
                    AppendColoredText($"[ERROR] Could not read databases from {connStrSetting.Name}: {ex.Message}\n", Color.Red);
                }
            }

            int total = targets.Count;
            if (total == 0)
            {
                progressBar1.Visible = false;
                MessageBox.Show("No databases found.");
                btnApplyGridChangesToAll.Enabled = true;
                return;
            }

            progressBar1.Maximum = total;
            progressBar1.Value = 0;

            await Task.Run(() =>
            {
                int count = 0;

                foreach (var target in targets)
                {
                    try
                    {
                        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(target.connectionString)
                        {
                            InitialCatalog = target.db
                        };

                        using SqlConnection conn = new SqlConnection(builder.ToString());
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {lastUsedTableName}", conn);
                        SqlCommandBuilder builderCmd = new SqlCommandBuilder(adapter);

                        DataTable clone = dataTable.Copy();
                        DataTable changes = clone.GetChanges();

                        if (changes != null && changes.Rows.Count > 0)
                        {
                            int updated = adapter.Update(clone);
                            Invoke(() =>
                                AppendColoredText($"[UPDATED] {updated} rows in {target.server}.{target.db}\n", Color.Violet));
                        }
                        else
                        {
                            Invoke(() =>
                                AppendColoredText($"[SKIPPED] No changes for {target.server}.{target.db}\n", Color.Orange));
                        }
                    }
                    catch (Exception ex)
                    {
                        Invoke(() =>
                            AppendColoredText($"[ERROR] {target.server}.{target.db}: {ex.Message}\n", Color.Red));
                    }

                    count++;
                    Invoke(() => progressBar1.Value = count);
                }
            });

            progressBar1.Visible = false;
            MessageBox.Show("Update completed.");
            btnApplyGridChangesToAll.Enabled = true;
        }


        private void execquery_Click(object sender, EventArgs e)
        {
            ExecuteQueryOnSelectedNode();
        }
        private void ExecuteQueryOnSelectedNode()
        {
            TreeNode clickedNode = treeView1.SelectedNode;
            if (clickedNode == null)
                return;

            // If it's a Table node (grandparent = server, parent = database)
            if (clickedNode.Parent != null && clickedNode.Parent.Parent != null)
            {
                string tableName = clickedNode.Text;
                string databaseName = clickedNode.Parent.Text;
                string serverName = clickedNode.Parent.Parent.Text;

                lblTableContext.Text = $"Selected Table: {tableName} | Database: {databaseName} | Server: {serverName}";

                lastUsedTableName = tableName;
                string connStrBase = ConfigurationManager.ConnectionStrings[serverName]?.ConnectionString;
                if (string.IsNullOrEmpty(connStrBase))
                {
                    MessageBox.Show("Connection string not found.");
                    return;
                }

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connStrBase)
                {
                    InitialCatalog = databaseName
                };

                try
                {
                    SqlConnection conn = new SqlConnection(builder.ToString());
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", conn);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                    adapter.SelectCommand.Connection = conn;
                    adapter.InsertCommand = commandBuilder.GetInsertCommand(true);
                    adapter.UpdateCommand = commandBuilder.GetUpdateCommand(true);
                    adapter.DeleteCommand = commandBuilder.GetDeleteCommand(true);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Tag = new Tuple<SqlConnection, SqlDataAdapter, DataTable>(conn, adapter, dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load table: {ex.Message}");
                    AppendColoredText($"[ERROR] Loading table {tableName}: {ex.Message}\n", Color.Red);
                }

                return;
            }

            // If the node is a Database (parent = server)
            if (clickedNode.Parent != null && clickedNode.Parent.Parent == null)
            {
                string databaseName = clickedNode.Text;
                string serverName = clickedNode.Parent.Text;
                string query = richTextBox2.Text.Trim();

                if (string.IsNullOrWhiteSpace(query))
                {
                    MessageBox.Show("Please enter a query in the rich text box.");
                    return;
                }

                string connStrBase = ConfigurationManager.ConnectionStrings[serverName]?.ConnectionString;
                if (string.IsNullOrEmpty(connStrBase))
                {
                    MessageBox.Show($"Connection string for {serverName} not found.");
                    return;
                }

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connStrBase)
                {
                    InitialCatalog = databaseName
                };

                try
                {
                    using (SqlConnection conn = new SqlConnection(builder.ToString()))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);

                        if (query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                            DataTable resultTable = new DataTable();
                            adapter.Fill(resultTable);

                            dataGridView1.DataSource = resultTable;
                            dataGridView1.Tag = new Tuple<SqlDataAdapter, DataTable>(adapter, resultTable);

                            dataGridView1.ReadOnly = false;
                            dataGridView1.AllowUserToAddRows = true;
                            dataGridView1.AllowUserToDeleteRows = true;

                            AppendColoredText($"\n[RESULT] {resultTable.Rows.Count} rows returned from {databaseName}.\n", Color.DarkGreen);
                        }
                        else
                        {
                            int affectedRows = cmd.ExecuteNonQuery();
                            AppendColoredText($"\n[RESULT] {affectedRows} rows affected in {databaseName}.\n",Color.DarkGreen);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error executing query: {ex.Message}");
                    AppendColoredText($"\n[ERROR] {ex.Message}\n",Color.Red);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void serversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddServers addser = new AddServers();
            addser.ShowDialog();
        }
    }
}
