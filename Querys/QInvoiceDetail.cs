using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerreteriaConsoleApp.Entities;

namespace FerreteriaConsoleApp.Querys;

public class QInvoiceDetail
{
    public static List<InvoiceDetail> GetInvoiceDetails()
    {
        List<InvoiceDetail> InvoiceDetailList = new List<InvoiceDetail>()
        {
            new InvoiceDetail(10001, 1000001, 1, 10, 2000),
            new InvoiceDetail(10002, 1000001, 5, 2, 2400),
            new InvoiceDetail(10003, 1000002, 2, 5, 1000),
            new InvoiceDetail(10004, 1000002, 7, 1, 6000),
            new InvoiceDetail(10005, 1000002, 3, 1, 1200),
            new InvoiceDetail(10006, 1000003, 4, 1, 5000),
            new InvoiceDetail(10007, 1000003, 1, 15, 3000),
            new InvoiceDetail(10008, 1000004, 7, 1, 6000),
            new InvoiceDetail(10009, 1000005, 6, 2, 4000),
            new InvoiceDetail(10010, 1000006, 5, 3, 3600),
            new InvoiceDetail(10011, 1000007, 1, 5, 1000),
            new InvoiceDetail(10012, 1000007, 2, 5, 1000),
            new InvoiceDetail(10013, 1000008, 7, 2, 12000),
            new InvoiceDetail(10014, 1000008, 6, 3, 6000),
            new InvoiceDetail(10015, 1000009, 4, 1, 5000),
            new InvoiceDetail(10016, 1000009, 2, 10, 2000),
            new InvoiceDetail(10017, 1000010, 5, 4, 4800)
        };
        return InvoiceDetailList;
    }
}
