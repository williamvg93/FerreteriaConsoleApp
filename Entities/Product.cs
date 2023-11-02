using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaConsoleApp.Entities;

public class Product
{
    private int id;
    private string name;
    private int unitPrice;
    private int quantity;
    private int minStock;
    private int maxStock;

    public Product() : base()
    {
    }
    public Product(int nId, string nName, int nUnitPrice, int nQuantity, int nMinStock, int nMaxStock)
    {
        this.id = nId;
        this.name = nName;
        this.unitPrice = nUnitPrice;
        this.quantity = nQuantity;
        this.minStock = nMinStock;
        this.maxStock = nMaxStock;
    }

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public int UnitPrice { get => unitPrice; set => unitPrice = value; }
    public int Quantity { get => quantity; set => quantity = value; }
    public int MinStock { get => minStock; set => minStock = value; }
    public int MaxStock { get => maxStock; set => maxStock = value; }
}
