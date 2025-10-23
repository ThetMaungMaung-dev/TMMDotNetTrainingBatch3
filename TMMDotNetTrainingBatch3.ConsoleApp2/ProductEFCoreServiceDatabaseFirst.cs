using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMMDotNetTrainingBatch3.ConsoleApp2.Database.AppDbContextModels;

namespace TMMDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductEFCoreServiceDatabaseFirst
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var list = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ProductId);
                Console.WriteLine(list[i].ProductName);

            }

        }
        public void Create()
        {
            AppDbContext db = new AppDbContext();
            var item = new TblProduct()
            {
                ProductName = "Pencil",
                Quantity = 150,
                Price = 500,
                DeleteFlag = false,
                CreatedDateTime = DateTime.Now,
            };
            db.TblProducts.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
        public void Update()
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == 10);

            if (item == null)
            {
                return;
            }
            item.ProductName = "Pencils";
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == 10);
            if (item == null)
            {
                return;
            }
            item.DeleteFlag = true;
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
