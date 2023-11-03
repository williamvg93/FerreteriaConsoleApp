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
    }
}