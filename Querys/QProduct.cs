using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public static void CreateColumsTable(string title)
    {
        Console.WriteLine("{0,52}", $"----- {title} ---- \n");

        Console.WriteLine("{0,-8} {1, -20} {2, -10} {3,-13} {4, -13} {5,3}", "Id", "Name", "Price", "Quantity", "MinStock", "MaxStock");
    }

    public static void ViewAllProduct(List<Product> productList)
    {
        CreateColumsTable("Product List");

        productList.ForEach(p => Console.WriteLine("{0,-8} {1, -20} {2, -10} {3,-13} {4, -13} {5,8}", p.Id, p.Name, p.UnitPrice, p.Quantity, p.MinStock, p.MaxStock));
    }
    public static void ViewProductsMinStock(List<Product> productList)
    {
        CreateColumsTable("Products that do not have the minimum stock quantities");

        var productMinStock = productList.Where(p => p.Quantity < p.MinStock).ToList<Product>();

        productMinStock.ForEach(p => Console.WriteLine("{0,-8} {1, -20} {2, -10} {3,-13} {4, -13} {5,8}", p.Id, p.Name, p.UnitPrice, p.Quantity, p.MinStock, p.MaxStock));
    }
}
