using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerreteriaConsoleApp.Entities;
using Newtonsoft.Json;

namespace FerreteriaConsoleApp;

public class Functions
{
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

    public static void CreateColumsProducts(string title)
    {
        Console.WriteLine("{0,52}", $"----- {title} ---- \n");

        Console.WriteLine("{0,-8} {1, -20} {2, -10} {3,-13} {4, -13} {5,3}", "Id", "Name", "Price", "Quantity", "MinStock", "MaxStock");
    }

}
