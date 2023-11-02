using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaConsoleApp.Entities;

public class InvoiceDetail
{
    private int id;
    private int idInv;
    private int idPro;
    private int quantity;
    private int value;

    public InvoiceDetail() : base() { }
    public InvoiceDetail(int id, int idInv, int idPro, int quantity, int value)
    {
        this.id = id;
        this.idInv = idInv;
        this.idPro = idPro;
        this.quantity = quantity;
        this.value = value;
    }

    public int Id { get => id; set => id = value; }
    public int IdInv { get => idInv; set => idInv = value; }
    public int IdPro { get => idPro; set => idPro = value; }
    public int Quantity { get => quantity; set => quantity = value; }
    public int Value { get => value; set => this.value = value; }
}
