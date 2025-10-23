using Microsoft.Data.SqlClient;
using System.Data;
using TMMDotNetTrainingBatch3.ConsoleApp2;

Console.WriteLine("Hello, World!");

ProductService productService = new ProductService();//DonetProduct
productService.Read();
productService.Create();
productService.Update();
productService.Delete();

SaleService saleService = new SaleService();//DonetSale
saleService.Read();
saleService.Create();

ProductDapperService productDapperService = new ProductDapperService();//DrapperProduct
productDapperService.Read();
productDapperService.Create();
productDapperService.Update();
productDapperService.Delete();

SaleDapperService saleDapperService = new SaleDapperService();//DapperSale
saleDapperService.Read();
saleDapperService.Create();

ProductEFCoreServiceModelFirst productEFCoreServiceMD = new ProductEFCoreServiceModelFirst();//ModelFirstProduct
productEFCoreServiceMD.Read();
productEFCoreServiceMD.Create();
productEFCoreServiceMD.Update();
productEFCoreServiceMD.Delete();

SaleEFCoreServiceModelFirst saleEFCoreServiceMD = new SaleEFCoreServiceModelFirst();//ModelFirstSale
saleEFCoreServiceMD.Read();
saleEFCoreServiceMD.Create();

ProductEFCoreServiceDatabaseFirst productEFCoreService = new ProductEFCoreServiceDatabaseFirst();//DatabaseFirstProduct
productEFCoreService.Read();
productEFCoreService.Create();
productEFCoreService.Update();
productEFCoreService.Delete();

SaleEFCoreServiceDatabaseFirst saleEFCoreService = new SaleEFCoreServiceDatabaseFirst();//DatabaseFirstSale
saleEFCoreService.Read();
saleEFCoreService.Create();


Console.ReadLine();