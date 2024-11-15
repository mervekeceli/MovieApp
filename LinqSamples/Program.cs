// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//DB first için gerekli migration işlemi: 
//dotnet ef dbcontext scaffold "Data Source=(localdb)\\MSSQLLocalDB;Database=Northwind;Integrated Security=SSPI;" "Microsoft.EntityFrameworkCore.SqlServer" --output-dir "Data" --context NorthwindContext
