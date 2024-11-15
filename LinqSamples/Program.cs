﻿// See https://aka.ms/new-console-template for more information
using LinqSamples.Data;

//DB first için gerekli migration işlemi: 
//dotnet ef dbcontext scaffold "Data Source=(localdb)\\MSSQLLocalDB;Database=Northwind;Integrated Security=SSPI;" "Microsoft.EntityFrameworkCore.SqlServer" --output-dir "Data" --context NorthwindContext
#region Select Sorguları
/*using (var db = new NorthwindContext())
{
    
    //var products = db.Products.ToList();
    //var products = db.Products.Select(p => new { p.ProductName, p.Category }).ToList();

    //var product = db.Products.First();
    //Console.WriteLine(product.ProductName + " -> " + product.UnitPrice);

    //var product1 = db.Products.Select(p=>new { p.ProductName, product.UnitPrice }).FirstOrDefault();
    //Console.WriteLine(product1.ProductName + " -> " + product1.UnitPrice);

    //foreach(var product in products)
    //{
    //    console.writeline(product.productname + " -> " + product.category.categoryname);
    //}     
}*/
#endregion

#region Filtreleme Sorguları

//using (var db = new NorthwindContext())
//{
//    //var products = db.Products.Where(p => p.UnitPrice > 18 && p.UnitPrice < 30).ToList();
//    //var products = db.Products.Select(x=>new { x.ProductName, x.UnitPrice}).Where(p => p.UnitPrice > 18 && p.UnitPrice < 30).ToList();
//    //var products = db.Products.Where(p => p.CategoryId == 1).ToList();
//    //var products = db.Products.Where(p => p.CategoryId > 1 && p.CategoryId < 5).ToList();
//    //var products = db.Products.Where(p => p.CategoryId == 1 || p.CategoryId == 5).ToList();

//    //var products = db.Products.Where(i => i.ProductName == "Chai").ToList();
//    var products = db.Products.Where(i => i.ProductName.Contains("Ch")).ToList();
//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ProductName + ' ' + product.UnitPrice);
//    }
//}

#endregion


#region Linq Select Sorgu Uygulamaları

//Tüm müşteri kayıtlarını getiriniz.
/*using (var db = new NorthwindContext())
{
    var customers = db.Customers.ToList();

    foreach (var customer in customers)
    {
        Console.WriteLine(customer.CompanyName);
    }
}*/


//Tüm müşterilerin sadece customerId ve ContactName klonlarını getiriniz.
/*using (var db = new NorthwindContext())
{
    var customers = db.Customers.Select(x => new { x.ContactName, x.CustomerId }).ToList();

    foreach (var customer in customers)
    {
        Console.WriteLine(customer.ContactName + " -> " + customer.CustomerId);
    }
}*/


//Almanya'da yaşayan müşterilerin adlarını getiriniz.
/*using (var db = new NorthwindContext())
{
    var customers = db.Customers.Where(x=>x.Country == "Germany").ToList();

    foreach (var customer in customers)
    {
        Console.WriteLine(customer.CompanyName);
    }
}*/


//"Diego Roel" isimli müşteri nerde yaşamaktadır?
/*using (var db = new NorthwindContext())
{
    var customer = db.Customers.Where(x => x.ContactName == "Diego Roel").FirstOrDefault();
    Console.WriteLine(customer.Address);
}*/


//Stokta olmayan ürünler hangileridir?
/*using(var db = new NorthwindContext())
{
    var noStockProducts = db.Products
        .Select(a => new { a.ProductName, a.UnitsInStock })
        .Where(i => i.UnitsInStock == 0).ToList();

    foreach (var product in noStockProducts)
    {
        Console.WriteLine(product.ProductName);
    }
}*/

//Tüm çalışanların ad ve soyadını tek kolon şeklinde getiriniz.
/*using(var db = new NorthwindContext())
{
    var employee = db.Employees.Select(i => new {FullName = i.FirstName + " " + i.LastName }).ToList();

    foreach(var e in employee)
    {
        Console.WriteLine(e.FullName);
    }
}*/

//Ürünler tablosundaki ilk beş kaydı alınız.

//using(var  db = new NorthwindContext())
//{
//    var products = db.Products.Take(5).ToList();

//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ProductName+ " " + product.ProductId);
//    }
//}
//Ürünler tablosundaki ikini 5 kaydı alınız
using (var db = new NorthwindContext())
{
    var products = db.Products.Skip(5).Take(5).ToList(); //Skip: öteleme işlemi

    foreach (var product in products)
    {
        Console.WriteLine(product.ProductName + " " + product.ProductId);
    }
}

#endregion



using(var db = new NorthwindContext())
{
    //var p1 = new Product() { ProductName = "Yen Ürün 2" };
    //db.Products.Add(p1);
    //db.SaveChanges();

    var category = db.Categories.Where(c => c.CategoryName == "Beverages").FirstOrDefault();

    var p1 = new Product() { ProductName = "Yeni ürün 3" };
    var p2 = new Product() { ProductName = "Yeni ürün 4" };

    category.Products.Add(p1);
    category.Products.Add(p2);
    db.SaveChanges();

    Console.WriteLine("Veri eklendi");
    Console.WriteLine(p1.ProductId);
    Console.WriteLine(p2.ProductId);
}

Console.ReadLine();