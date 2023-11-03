using System.Collections;
using FerreteriaConsoleApp;
using FerreteriaConsoleApp.Dto;
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

        bool controWhile = true;
        while (controWhile)
        {
            Console.Clear();
            System.Console.WriteLine();
            byte optionMen = Functions.MainMenu();

            switch (optionMen)
            {
                case 1:
                    /* View All Products */
                    Console.Clear();
                    QProduct.ViewAllProduct(productList);
                    Console.ReadKey();
                    break;
                case 2:
                    /* See Products that do not have the minimum stock quantities */
                    Console.Clear();
                    QProduct.ViewProductsMinStock(productList);
                    Console.ReadKey();
                    break;
                case 3:
                    /* See Products that need to be ordered */
                    Console.Clear();
                    QProduct.ViewProductsNeedStock(productList);
                    Console.ReadKey();
                    break;
                case 4:
                    /* list January Invoices  */
                    Console.Clear();
                    QInvoice.ViewInvoicesByMonth(invoiceList);
                    Console.ReadKey();
                    break;
                case 5:
                    /* List of Product of Invoice  */
                    Console.Clear();
                    QInvoice.ViewInvoiceProducts(invoiceList, productList, invDetailList);
                    Console.ReadKey();
                    break;
                case 6:
                    /* View Total Inventory */
                    Console.Clear();
                    QProduct.TotalInventory(productList);
                    Console.ReadKey();
                    break;
                case 7:
                    controWhile = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Enter a Valid Option !!!!, Pres a Key to Continue.");
                    break;
            }
        }
    }
}