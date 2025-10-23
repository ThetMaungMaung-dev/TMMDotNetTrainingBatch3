using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMMDotNetTrainingBatch3.ConsoleApp2
{
    public class SaleEFCoreServiceModelFirst
    {
        private readonly ModelFirstAppDbContextSale _db;
        private readonly ModelFirstAppDbContextProduct _db2;
        public SaleEFCoreServiceModelFirst()
        {
            _db = new ModelFirstAppDbContextSale();
            _db2 = new ModelFirstAppDbContextProduct();
        }
        public void Read()
        {
            var lts = _db.Sales.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lts.Count; i++)
            {
                Console.WriteLine(lts[i].SaleId);
                Console.WriteLine(lts[i].Price);
            }
        }
        public void Create()
        {
            const int productId = 2;
            const int saleQuantity = 20;
            const int salePrice = 4500;
            
            var product = _db2.Products.FirstOrDefault(p => p.ProductId == productId);

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

            var sale = new Tbl_Sale
            {
                ProductId = productId,
                Quantity = saleQuantity,
                Price = salePrice,
                DeleteFlag = false,
                CreatedDateTime = DateTime.Now,
                ModifiedDateTime = DateTime.Now
            };

            _db.Sales.Add(sale);

            product.Quantity -= saleQuantity;

            int result = _db.SaveChanges();

            string message = result > 0 ? "Saving successful." : "Saving failed.";
            Console.WriteLine(message);
        }
    }
}
