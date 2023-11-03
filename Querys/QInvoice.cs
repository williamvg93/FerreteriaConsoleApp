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
            new Invoice(1000001, new DateTime(2023, 01, 10), 1098739851, 50000),
            new Invoice(1000002, new DateTime(2023, 01, 08), 1099220651, 50000),
            new Invoice(1000003, new DateTime(2023, 01, 20), 1097521547, 50000),
            new Invoice(1000004, new DateTime(2023, 01, 15), 1098739851, 50000),
            new Invoice(1000005, new DateTime(2023, 02, 07), 1099220651, 50000),
            new Invoice(1000006, new DateTime(2023, 02, 27), 1097521547, 50000),
            new Invoice(1000007, new DateTime(2023, 05, 10), 1099823365, 50000),
            new Invoice(1000008, new DateTime(2023, 06, 02), 1095587412, 50000),
            new Invoice(1000009, new DateTime(2023, 08, 30), 1098739851, 50000),
            new Invoice(1000010, new DateTime(2023, 12, 25), 1098885147, 50000),
        };
        return InvoiceList;
    }

    public static void ViewInvoicesByMonth(List<Invoice> invoicesList)
    {

        Console.WriteLine("{0,52}", "----- January Invoices ---- \n");

        Console.WriteLine("{0,-8} {1, 20} ", "Id", "Date");

        var invoicesMonth = invoicesList.Where(i => i.CreatedDate.ToString("MM") == "01").OrderBy(i => i.CreatedDate).ToList<Invoice>();

        invoicesMonth.ForEach(i => Console.WriteLine("{0,-8} {1,35}", i.Id, i.CreatedDate.ToString("D")));

    }
    public static void ViewInvoiceProducts(List<Invoice> invoicesList, List<Product> productList, List<InvoiceDetail> invoiceDetailsList, int idInvo)
    {

        Console.WriteLine("{0,52}", $"----- List of Product of Invoice #{idInvo}  ---- \n");

        Console.WriteLine("{0,-8} {1, 12} ", "Id", "Name");

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
                         Name = pro.Name
                     }).ToList<InvoiceProductsDto>();

        invoiceProducts.ForEach(i => Console.WriteLine("{0,-8} {1,12}", i.Id, i.Name));
    }
}
