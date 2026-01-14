# WPolyQuery V 1.0

A .NET desktop application for executing SQL queries across multiple database servers using configurable connections.

---

## Features

- Connect to multiple SQL Server instances simultaneously.
- Browse available databases and tables using a tree view.
- Execute `SELECT` queries across all databases and merge results.
- Execute non-select queries (`INSERT`, `UPDATE`, `DELETE`) across multiple databases.
- Editable results grid with the ability to apply changes to all databases.
- Syntax highlighting for SQL keywords, strings, and comments.
- Live progress feedback for query execution and connections.
- Error handling with colored output in the log.

---
## How to Use

1. Configure Connections Strings 
   - Go to `App.config` and define your connection strings under `<connectionStrings>`.  
   - Example:
   ```xml
   <add name="Server1" connectionString="Data Source=SERVER1;Initial Catalog=master;User ID=sa;Password=yourpassword;" providerName="System.Data.SqlClient" />

2. Load Servers

 - When the application starts, it reads the configured servers and loads them into the left panel.

 - Click Start to connect and list available databases.

3. Filter Databases (Optional)

 - Type part of a database name in the search box to filter which databases appear.

 - Press Start again to apply the filter.

4. Expand and Browse

 - Expand any server to see its databases.

 - Expand a database to see its tables.

5. Select a Table

 - Double-click on a table node to load its data into the grid.

 - You can edit data and apply changes.

6. Write a Custom Query

 - Type your SQL query into the rich text area (e.g., SELECT * FROM TableName).

 - Select a database node (not a table) and click Exec Query to run your custom SQL.

7. Execute on All Databases

 - Use the Exec ALL button to run the query on all connected databases.

 - Use Exec TFA to apply grid/table changes to all databases.

Important Notes:

 * Only queries starting with SELECT load editable results.

 * Always validate your query before executing on multiple databases.

 * Error messages and logs appear in the bottom log box.

Typical Use Cases:

 * Running reports across multiple customer databases.

 * Applying schema or data updates across distributed environments.

 * Quickly viewing data from many databases without switching tools.

## Screenshots

<img width="1227" height="677" alt="image" src="https://github.com/user-attachments/assets/b35d31b1-db0e-4a5e-9883-1cf7db7f6466" />

---

## Requirements

- Windows 10 or higher
- .NET Framework 4.8
- Visual Studio 2022 (for development)
- SQL Server instances accessible with proper credentials

---

## Getting Started

1. Clone the repository:


