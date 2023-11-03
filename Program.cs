using System.Collections;
using FerreteriaConsoleApp;
using FerreteriaConsoleApp.Entities;
using FerreteriaConsoleApp.Querys;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Runingggg !");

        List<Product> productList = QProduct.GetProducts();
        List<Client> clientList = QClient.GetClients();
        List<Invoice> invoiceList = QInvoice.GetInvoices();
        List<InvoiceDetail> invDetailList = QInvoiceDetail.GetInvoiceDetails();

        Functions.SaveProduct(productList);
        Functions.SaveClient(clientList);
        Functions.SaveInvoice(invoiceList);
        Functions.SaveInvoiceDetail(invDetailList);




        Console.Clear();
        System.Console.WriteLine();

        /* View All Products */
        QProduct.ViewAllProduct(productList);

        System.Console.WriteLine("\n\n");
        /* See Products that do not have the minimum stock quantities */
        QProduct.ViewProductsMinStock(productList);

        System.Console.WriteLine("\n\n");
        /* See Products that need to be ordered */
        QProduct.ViewProductsNeedStock(productList);

        System.Console.WriteLine("\n\n");
        /* list January Invoices  */
        QInvoice.ViewInvoicesByMonth(invoiceList);

        System.Console.WriteLine("\n\n");
        /* List of Product of Invoice  */
        QInvoice.ViewInvoiceProducts(invoiceList, productList, invDetailList, 1000002);

        System.Console.WriteLine("\n\n");
        QProduct.TotalInventory(productList);
    }
}