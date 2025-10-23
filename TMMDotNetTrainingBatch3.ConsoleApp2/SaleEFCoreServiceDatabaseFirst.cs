using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMMDotNetTrainingBatch3.ConsoleApp2.Database.AppDbContextModels;

namespace TMMDotNetTrainingBatch3.ConsoleApp2
{
    public class SaleEFCoreServiceDatabaseFirst
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var list = db.TblSales.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].SaleId);
                Console.WriteLine(list[i].Price);

            }

        }
        public void Create()
        {
            using var db = new AppDbContext();

            const int productId = 3;
            const int saleQuantity = 5;
            const int salePrice = 1300;

            var product = db.TblProducts.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            if (product.Quantity < saleQuantity)
            {
                Console.WriteLine("Insufficient stock.");
                return;
            }

            var sale = new TblSale
            {
                ProductId = productId,
                Quantity = saleQuantity,
                Price = salePrice,
                DeleteFlag = false,
                CreatedDateTime = DateTime.Now,
                ModifiedDateTime = DateTime.Now
            };

            db.TblSales.Add(sale);

            product.Quantity -= saleQuantity;
            product.ModifiedDateTime = DateTime.Now;

            int result = db.SaveChanges();

            Console.WriteLine(result > 0 ? "Transaction Successful." : "Transaction Failed.");
        }
    }
}
