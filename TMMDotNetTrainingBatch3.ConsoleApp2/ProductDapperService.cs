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
    public class ProductDapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Batch3MiniPOS",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"SELECT
                        ProductId, ProductName, Quantity, Price, DeleteFlag
                            FROM Tbl_Product
                         WHERE DeleteFlag = 0";

                var lts = db.Query<ProductList>(query).ToList();

                for (int i = 0; i < lts.Count; i++)
                {
                    Console.WriteLine(lts[i].ProductId);
                    Console.WriteLine(lts[i].ProductName);
                }
            }
        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"INSERT INTO Tbl_Product (
                                    ProductName, 
                                    Quantity, 
                                    Price, 
                                    DeleteFlag,
                                    CreatedDateTime,
                                    ModifiedDateTime
                                ) VALUES (
                                    'Lemon',
                                    30,
                                    500,
                                    0,
                                    GETDATE(),
                                    GETDATE()
                                )";

                int result = db.Execute(query);

                string message = result > 0 ? "Saving successful." : "Saving failed.";
                Console.WriteLine(message);
            }
        }

        public void Update()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"UPDATE Tbl_Product SET
                                    ProductName = 'Kiwi',
                                    Price = 3500
                                WHERE ProductId = 1006";

                int result = db.Execute(query);

                string message = result > 0 ? "Updated successful." : "Updated failed.";
                Console.WriteLine(message);
            }
        }

        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"DELETE FROM Tbl_Product WHERE ProductId = 1002";

                int result = db.Execute(query);

                string message = result > 0 ? "Deleted successful." : "Deleted failed.";
                Console.WriteLine(message);
            }
        }
    }

    public class ProductList
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Quanlity { get; set; }
        public int Price { get; set; }
        public bool DeleteFalg { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
