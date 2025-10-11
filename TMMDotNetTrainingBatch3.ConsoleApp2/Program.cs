// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;

//Console.WriteLine("Hello, World!");
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = "."; //servername
sqlConnectionStringBuilder.InitialCatalog = "Batch3MiniPOS"; //Databasename
sqlConnectionStringBuilder.UserID = "sa";//Username
sqlConnectionStringBuilder.Password = "sasa@123";//Password
sqlConnectionStringBuilder.TrustServerCertificate = true;//

SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
connection.Open();

string query = @"SELECT [ProductId]
      ,[ProductName]
      ,[Price]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Product]";

SqlCommand command = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(command);
DataTable dataTable = new DataTable();
adapter.Fill(dataTable);

connection.Close();

for (int i = 0;i < dataTable.Rows.Count; i++)
{
    DataRow row = dataTable.Rows[i];
    //Console.WriteLine(row["ProductId"]);
    int rownumber = i + 1;
    decimal price = Convert.ToDecimal(row["Price"]);
    Console.WriteLine(rownumber.ToString() + ". " + row["ProductName"] + "(" + price.ToString("n0")+ ")");
    //Console.WriteLine(rownumber.ToString() + ". " + row["ProductName"] + "(" + row["Price"] + ")");

    //Console.WriteLine("Price >>>>" + row["Price"]);
    //Console.WriteLine("----------------------------------");
}
Console.ReadLine();
