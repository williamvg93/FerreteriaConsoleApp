using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FerreteriaConsoleApp.Entities;
using Newtonsoft.Json;

namespace FerreteriaConsoleApp;

public class Functions
{
    public static byte MainMenu()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("{0,40}", "-------------------------");
        Console.WriteLine("{0,40}", "----- Ferreteria App ----");
        Console.WriteLine("{0,40}", "-------------------------");
        Console.WriteLine();
        Console.WriteLine("{0,30}", " Main Menú \n");
        Console.WriteLine("{0,3}", " 1) -> View All Products");
        Console.WriteLine("{0,3}", " 2) -> See Products that do not have the minimum stock quantities");
        Console.WriteLine("{0,3}", " 3) -> See Products that need to be ordered");
        Console.WriteLine("{0,3}", " 4) -> list Invoices by Month");
        Console.WriteLine("{0,3}", " 5) -> List of Product of Invoice");
        Console.WriteLine("{0,3}", " 6) -> View Total Inventory");
        Console.WriteLine("{0,3}", " 7) -> Exit App \n");
        return Byte.Parse(GetExactVal("int", "1", "Enter menu opcion", "Only numbers"));
    }
    public static void SaveProduct(List<Product> productList)
    {
        string JsonData = JsonConvert.SerializeObject(productList, Formatting.Indented);
        File.WriteAllText("Data/Product.json", JsonData);
    }
    public static void SaveClient(List<Client> clientList)
    {
        string JsonData = JsonConvert.SerializeObject(clientList, Formatting.Indented);
        File.WriteAllText("Data/Client.json", JsonData);
    }
    public static void SaveInvoice(List<Invoice> invoiceList)
    {
        string JsonData = JsonConvert.SerializeObject(invoiceList, Formatting.Indented);
        File.WriteAllText("Data/Invoice.json", JsonData);
    }
    public static void SaveInvoiceDetail(List<InvoiceDetail> invoiceDetailList)
    {
        string JsonData = JsonConvert.SerializeObject(invoiceDetailList, Formatting.Indented);
        File.WriteAllText("Data/InvoiceDetail.json", JsonData);
    }

    public static string GetExactVal(string valType, string dataLen, string msg, string msgRestric)
    {
        string newData = null;
        string regExp;
        switch (valType)
        {
            case "strSpace":
                regExp = @"^[a-zA-ZÀ-ÿ\u00f1\u00d1\x20]{" + dataLen + "}$";
                break;
            case "strDir":
                regExp = @"^[a-zA-Z0-9À-ÿ_\u00f1\u00d1\-\#\.\x20]{" + dataLen + "}$";
                break;
            case "strEmail":
                regExp = @"^([\w\.\-_]+)@([\w\-]+)((\.(\w){2,4})+)$";
                break;
            case "int":
                regExp = @"^[0-9]{" + dataLen + "}$";
                break;
            default:
                regExp = @"^[\s\S]{" + dataLen + "}$";
                break;
        }
        /* Console.WriteLine(regExp); */
        bool contGetExa = true;
        while (contGetExa)
        {
            Console.WriteLine($"Enter the {msg}");
            newData = Console.ReadLine();
            if (Regex.IsMatch(newData, regExp))
            {
                newData = Regex.Replace(newData, @"\s+", " ").Trim();
                /* Console.WriteLine(newData); */
                contGetExa = false;
            }
            else
            {
                Console.WriteLine($"{msgRestric} are allowed, The {msg} must be at least {dataLen} characters.");
            }
        }
        return newData;
    }

    public static void CreateColumsProducts(string title)
    {
        Console.WriteLine("{0,52}", $"----- {title} ---- \n");

        Console.WriteLine("{0,-8} {1, -20} {2, -10} {3,-13} {4, -13} {5,3}", "Id", "Name", "Price", "Quantity", "MinStock", "MaxStock");
    }

}
