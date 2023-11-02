using System.Collections;
using FerreteriaConsoleApp;
using FerreteriaConsoleApp.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Runingggg !");

        List<Product> ProductList = new List<Product>();
        List<Client> ClientList = new List<Client>();
        List<Invoice> InvoiceList = new List<Invoice>();
        List<InvoiceDetail> InvoiceDetailList = new List<InvoiceDetail>();
        DateTime fecha = new DateTime(2023, 01, 20);


        Product newProduct = new Product(1, "Tornillo", 2500, 30, 100, 1000);
        Client newClient = new Client(1, "William", "correo@correo.com");
        Invoice newInvoice = new Invoice(10001, new DateTime(2023, 01, 20), 1, 50000);
        InvoiceDetail newInvoiceDetail = new InvoiceDetail(1, 10001, 1, 30, 30000);


        ProductList.Add(newProduct);
        ClientList.Add(newClient);
        InvoiceList.Add(newInvoice);
        InvoiceDetailList.Add(newInvoiceDetail);

        Functions.SaveProduct(ProductList);
        Functions.SaveClient(ClientList);
        Functions.SaveInvoice(InvoiceList);
        Functions.SaveInvoiceDetail(InvoiceDetailList);
    }
}