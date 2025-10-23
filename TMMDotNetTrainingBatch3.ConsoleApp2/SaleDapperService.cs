using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace TMMDotNetTrainingBatch3.ConsoleApp2
{
    public class SaleDapperService
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
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"SELECT [SaleId]
                                  ,[ProductId]
                                  ,[Quantity]
                                  ,[Price]
                                  ,[DeleteFlag]
                                  ,[CreatedDateTime]
                                  ,[ModifiedDateTime]
                              FROM [dbo].[Tbl_Sale]";

                List<SaleList> lst = db.Query<SaleList>(query).ToList();

                for (int i = 0; i < lst.Count; i++)
                {
                    Console.WriteLine(lst[i].SaleId);
                    Console.WriteLine(lst[i].Price);

                }
            }
        }
        
        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                const int productId = 1;
                const int saleQuantity = 5;
                const int salePrice = 2500;

                string getQuantityQuery = @"SELECT Quantity FROM [dbo].[Tbl_Product] WHERE ProductId = @ProductId";
                string insertSaleQuery = @"INSERT INTO [dbo].[Tbl_Sale]
                                   ([ProductId], [Quantity], [Price], [DeleteFlag], [CreatedDateTime])
                                   VALUES (@ProductId, @Quantity, @Price, 0, SYSDATETIME())";
                string updateProductQuery = @"UPDATE [dbo].[Tbl_Product]
                                      SET Quantity = Quantity - @Quantity
                                      WHERE ProductId = @ProductId";

                int currentQuantity = db.ExecuteScalar<int>(getQuantityQuery, new { ProductId = productId });

                if (currentQuantity >= saleQuantity)
                {
                    int insertResult = db.Execute(insertSaleQuery, new
                    {
                        ProductId = productId,
                        Quantity = saleQuantity,
                        Price = salePrice
                    });

                    Console.WriteLine(insertResult > 0 ? "Saving Successful." : "Saving Failed.");

                    int updateResult = db.Execute(updateProductQuery, new
                    {
                        ProductId = productId,
                        Quantity = saleQuantity
                    });

                    Console.WriteLine(updateResult > 0 ? "Updating Successful." : "Updating Failed.");
                }
                else
                {
                    Console.WriteLine("Insufficient stock.");
                }
            }
        }
    }

    public class SaleList
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
