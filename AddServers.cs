using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Wdbexec
{
    public partial class AddServers : Form
    {
        public AddServers()
        {
            InitializeComponent();
            LoadConnectionsToGrid(); // 🔄 Load grid on form load

      
        }

        private void btnAddConnection_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string user = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(server) ||
                string.IsNullOrWhiteSpace(database) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            string connectionString = $"Server={server};Database={database};User Id={user};Password={password};";

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringsSection section = config.ConnectionStrings;

                section.ConnectionStrings.Remove(name); // remove if already exists
                section.ConnectionStrings.Add(new ConnectionStringSettings(name, connectionString));

                if (!section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                }

                section.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Connection added and encrypted successfully!");
                LoadConnectionsToGrid(); // 🔄 Refresh grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadConnectionsToGrid()
        {
            var table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Server");
            table.Columns.Add("Database");
            table.Columns.Add("User Id");
            table.Columns.Add("Password");

            foreach (ConnectionStringSettings setting in ConfigurationManager.ConnectionStrings)
            {
                if (!string.IsNullOrWhiteSpace(setting.Name) &&
                    !setting.Name.StartsWith("LocalSqlServer"))
                {
                    var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(setting.ConnectionString);
                    table.Rows.Add(setting.Name, builder.DataSource, builder.InitialCatalog, builder.UserID, builder.Password);
                }
            }

            dataGridView2.DataSource = table;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.Dock = DockStyle.Fill;
        }

        private void btndelconnection_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            // Get the selected connection name (from first column)
            string selectedName = dataGridView2.SelectedRows[0].Cells["Name"].Value?.ToString();

            if (string.IsNullOrEmpty(selectedName))
            {
                MessageBox.Show("Invalid selection.");
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete '{selectedName}'?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringsSection section = config.ConnectionStrings;

                if (section.ConnectionStrings[selectedName] != null)
                {
                    section.ConnectionStrings.Remove(selectedName);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    MessageBox.Show("Connection deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Connection not found.");
                }

                LoadConnectionsToGrid(); // 🔄 Refresh grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
