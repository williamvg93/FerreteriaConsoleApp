using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
using FerreteriaConsoleApp.Dto;
using FerreteriaConsoleApp.Entities;

namespace FerreteriaConsoleApp.Querys;

public class QProduct
{
    public static List<Product> GetProducts()
    {
        List<Product> ProductList = new List<Product>()
        {
            new Product(){Id = 1, Name = "tornillo", UnitPrice = 200, Quantity = 100, MinStock = 50, MaxStock = 150},
            new Product(){Id = 2, Name = "tuerca", UnitPrice = 200, Quantity = 80, MinStock = 60, MaxStock = 80},
            new Product(){Id = 3, Name = "cinta", UnitPrice = 1200, Quantity = 18, MinStock = 25, MaxStock = 30},
            new Product(){Id = 4, Name = "martillo", UnitPrice = 5000, Quantity = 4, MinStock = 10, MaxStock = 15},
            new Product(){Id = 5, Name = "tubo", UnitPrice = 1200, Quantity = 30, MinStock = 15, MaxStock = 30},
            new Product(){Id = 6, Name = "pegante", UnitPrice = 2000, Quantity = 5, MinStock = 5, MaxStock = 10},
            new Product(){Id = 7, Name = "brocha", UnitPrice = 6000, Quantity = 10, MinStock = 5, MaxStock = 10}
        };

        return ProductList;
    }

    public static void ViewAllProduct(List<Product> productList)
    {
        Console.WriteLine("{0,20}", "Product List\n");

        var table = new ConsoleTable("Id", "Name", "Unit Price", "Quantity", "MinStock", "MaxStock");
        productList.ForEach(p => table.AddRow(p.Id, p.Name, p.UnitPrice, p.Quantity, p.MinStock, p.MaxStock));
        table.Write();
    }
    public static void ViewProductsMinStock(List<Product> productList)
    {
        Console.WriteLine("{0,5}", "Products that do not have the minimum stock quantities\n");

        var productMinStock = productList.Where(p => p.Quantity < p.MinStock).ToList<Product>();

        var table = new ConsoleTable("Id", "Name", "Quantity", "MinStock", "MaxStock");
        productMinStock.ForEach(p => table.AddRow(p.Id, p.Name, p.Quantity, p.MinStock, p.MaxStock));
        table.Write();
    }
    public static void ViewProductsNeedStock(List<Product> productList)
    {
        Console.WriteLine("{0,5}", "Products that need to be ordered\n");
        var table = new ConsoleTable("Id", "Name", "QuantitiesNeeded");

        var productMinStock = productList.Where(p => p.Quantity < p.MaxStock).Select(p => new ProductDto { Name = p.Name, Stock = p.MaxStock - p.Quantity, Id = p.Id }).ToList<ProductDto>();

        productMinStock.ForEach(p => table.AddRow(p.Id, p.Name, p.Stock));
        table.Write();
    }

    public static void TotalInventory(List<Product> productList)
    {
        Console.WriteLine("{0,10}", "----- Total inventory value ---- \n");
        var table = new ConsoleTable("Name", "TotalValue");

        var invoiceProducts =
                    (from pro in productList
                     select new TotalInventoryDto
                     {
                         Total = pro.Quantity * pro.UnitPrice,
                         Name = pro.Name
                     }).ToList<TotalInventoryDto>();

        invoiceProducts.ForEach(p => table.AddRow(p.Name, p.Total));
        table.Write();
        System.Console.WriteLine();
        var total = invoiceProducts.Sum(p => p.Total);
        Console.WriteLine($"Total inventory value : {total}");
    }
}
