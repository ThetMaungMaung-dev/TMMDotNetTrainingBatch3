using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMMDotNetTrainingBatch3.ConsoleApp2
{
    public class SaleService
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Batch3MiniPOS",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"SELECT [SaleId]
                          ,[ProductId]
                          ,[Quantity]
                          ,[Price]
                          ,[DeleteFlag]
                          ,[CreatedDateTime]
                          ,[ModifiedDateTime]
                      FROM [dbo].[Tbl_Sale]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);

                Console.WriteLine(rowNo.ToString() + ". " + "Sale: " + row["SaleId"] + ", Price: (" + price.ToString("n0") + ")");

            }
        }

        public void Create()
        {
            string insertSaleQuery = @"INSERT INTO [dbo].[Tbl_Sale]
                                ([ProductId], [Quantity], [Price], [DeleteFlag], [CreatedDateTime])
                                VALUES (1, 5, 3500, 0, SYSDATETIME())";

            string getProductQuantityQuery = @"SELECT Quantity FROM [dbo].[Tbl_Product] WHERE ProductId = 1";

            string updateProductQuery = @"UPDATE [dbo].[Tbl_Product]
                                  SET Quantity = Quantity - 5
                                  WHERE ProductId = 1";

            using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                connection.Open();

                using (SqlCommand getQtyCmd = new SqlCommand(getProductQuantityQuery, connection))
                {
                    object result = getQtyCmd.ExecuteScalar();
                    int currentQty = result != null ? Convert.ToInt32(result) : 0;

                    if (currentQty >= 5)
                    {
                        
                        using (SqlCommand insertCmd = new SqlCommand(insertSaleQuery, connection))
                        {
                            int insertResult = insertCmd.ExecuteNonQuery();
                            Console.WriteLine(insertResult > 0 ? "Saving Successful." : "Saving Failed.");
                        }

                        
                        using (SqlCommand updateCmd = new SqlCommand(updateProductQuery, connection))
                        {
                            int updateResult = updateCmd.ExecuteNonQuery();
                            Console.WriteLine(updateResult > 0 ? "Updating Successful." : "Updating Failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantity is not enough!!!");
                    }
                }
            }
        }

    }
}
