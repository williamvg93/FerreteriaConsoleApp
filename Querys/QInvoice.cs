using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
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
        string respMont = Functions.GetExactVal("int", "2", "number of Month(01 - 12), Example 05", "only numbers");

        Console.Clear();
        Console.WriteLine("{0,20}", $"----- Invoices ---- \n");

        var invoicesMonth = invoicesList.Where(i => i.CreatedDate.ToString("MM") == respMont).OrderBy(i => i.CreatedDate).ToList<Invoice>();

        if (invoicesMonth.Count > 0)
        {
            var table = new ConsoleTable("Id", "CreationDate", "Total");
            invoicesMonth.ForEach(i => table.AddRow(i.Id, i.CreatedDate.ToString("D"), i.Total));
            table.Write();
            System.Console.WriteLine();
            Console.WriteLine($"Total value of Invoices: {invoicesMonth.Sum(i => i.Total)}");
        }
        else
        {
            Console.WriteLine("{0,6}", $" There Are no invoices for that month of ({respMont}).");
        }

    }
    public static void ViewInvoiceProducts(List<Invoice> invoicesList, List<Product> productList, List<InvoiceDetail> invoiceDetailsList)
    {
        int idInvo = int.Parse(Functions.GetExactVal("int", "7", "invoice ID", "only numbers"));
        Console.Clear();
        Console.WriteLine($"List of Product of Invoice # {idInvo} \n");
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

        if (invoiceProducts.Count > 0)
        {
            var table = new ConsoleTable("Id", "Name", "Quantity");
            invoiceProducts.ForEach(i => table.AddRow(i.Id, i.Name, i.Quantity));
            table.Write();
        }
        else
        {
            Console.WriteLine("{0,6}", $" Invoice ID ({idInvo}) does not Exist");
        }
    }
}
