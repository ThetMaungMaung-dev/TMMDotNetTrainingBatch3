ADO.NET
Dapper
EFCore

-Model First
-Code First
-Database First

dotnet ef dbcontext scaffold "Server=.;Database=Batch3MiniPOS;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f