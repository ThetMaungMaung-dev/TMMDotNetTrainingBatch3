using System;
using System.Collections.Generic;

namespace TMMDotNetTrainingBatch3.ConsoleApp2.Database.AppDbContextModels;

public partial class TblSale
{
    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public bool DeletFlag { get; set; }

    public DateOnly CrateDateTime { get; set; }
}
