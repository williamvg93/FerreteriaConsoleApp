using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerreteriaConsoleApp.Dto;
using FerreteriaConsoleApp.Entities;

namespace FerreteriaConsoleApp.Querys;

public class QInvoice
{
    public static List<Invoice> GetInvoices()
    {
        List<Invoice> InvoiceList = new List<Invoice>()
        {
            new Invoice(1000001, new DateTime(2023, 01, 10), 1098739851, 4400),
            new Invoice(1000002, new DateTime(2023, 01, 08), 1099220651, 19000),
            new Invoice(1000003, new DateTime(2023, 01, 20), 1097521547, 8000),
            new Invoice(1000004, new DateTime(2023, 01, 15), 1098739851, 6000),
            new Invoice(1000005, new DateTime(2023, 02, 07), 1099220651, 4000),
            new Invoice(1000006, new DateTime(2023, 02, 27), 1097521547, 3600),
            new Invoice(1000007, new DateTime(2023, 05, 10), 1099823365, 2000),
            new Invoice(1000008, new DateTime(2023, 06, 02), 1095587412, 18000),
            new Invoice(1000009, new DateTime(2023, 08, 30), 1098739851, 7000),
            new Invoice(1000010, new DateTime(2023, 12, 25), 1098885147, 4800)
        };
        return InvoiceList;
    }

    public static void ViewInvoicesByMonth(List<Invoice> invoicesList)
    {
        string respMont = Functions.GetExactVal("int", "2", "Enter the numbre of Month(01 - 12), Example 05", "only numbers");

        Console.Clear();
        Console.WriteLine("{0,52}", $"----- Invoices ---- \n");
        Console.WriteLine("{0,-8} {1, 20} {2,25} ", "Id", "Date", "Total");

        var invoicesMonth = invoicesList.Where(i => i.CreatedDate.ToString("MM") == respMont).OrderBy(i => i.CreatedDate).ToList<Invoice>();

        if (invoicesMonth.Count > 0)
        {
            invoicesMonth.ForEach(i => Console.WriteLine("{0,-8} {1,35} {2,10}", i.Id, i.CreatedDate.ToString("D"), i.Total));
            System.Console.WriteLine("\n");
            Console.WriteLine($"Total value of Invoices: {invoicesMonth.Sum(i => i.Total)}");
        }
        else
        {
            Console.WriteLine("{0,6}", $" There Are no invoices for that month of ({respMont}).");
        }

    }
    public static void ViewInvoiceProducts(List<Invoice> invoicesList, List<Product> productList, List<InvoiceDetail> invoiceDetailsList)
    {
        int idInvo = int.Parse(Functions.GetExactVal("int", "7", "Enter the invoice ID", "only numbers"));
        Console.Clear();
        Console.WriteLine("{0,52}", $"----- List of Product of Invoice #{idInvo}  ---- \n");

        Console.WriteLine("{0,-8} {1, 12} {2, 12} ", "Id", "Name", "Quantity");

        var invoiceProducts =
                    (from inv in invoicesList
                     join invDet in invoiceDetailsList
                     on inv.Id equals invDet.IdInv
                     join pro in productList
                     on invDet.IdPro equals pro.Id
                     where inv.Id == idInvo
                     select new InvoiceProductsDto
                     {
                         Id = pro.Id,
                         Name = pro.Name,
                         Quantity = invDet.Quantity
                     }).ToList<InvoiceProductsDto>();

        invoiceProducts.ForEach(i => Console.WriteLine("{0,-8} {1,12} {2,12}", i.Id, i.Name, i.Quantity));

        if (invoiceProducts.Count > 0)
        {
            invoiceProducts.ForEach(i => Console.WriteLine("{0,-8} {1,12} {2,12}", i.Id, i.Name, i.Quantity));
        }
        else
        {
            Console.WriteLine("{0,6}", $" Invoice ID ({idInvo}) does not Exist");
        }
    }
}
