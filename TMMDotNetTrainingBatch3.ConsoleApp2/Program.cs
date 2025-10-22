using Microsoft.Data.SqlClient;
using System.Data;
using TMMDotNetTrainingBatch3.ConsoleApp2;

Console.WriteLine("Hello, World!");

ProductService productService = new ProductService();
productService.Read();
productService.Create();
productService.Update();
productService.Delete();

ProductDapperService productDapperService = new ProductDapperService();
productDapperService.Read();
productDapperService.Create();
productDapperService.Update();
productDapperService.Delete();

ProductEFCoreService productEFCoreService = new ProductEFCoreService();
productEFCoreService.Read();
productEFCoreService.Create();
productEFCoreService.Update();
productEFCoreService.Delete();

Console.ReadLine();