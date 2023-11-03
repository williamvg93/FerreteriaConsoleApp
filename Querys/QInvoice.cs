using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
}
