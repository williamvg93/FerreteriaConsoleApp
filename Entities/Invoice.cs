using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaConsoleApp.Entities;

public class Invoice
{
    private int id;
    private DateTime createdDate;
    private int idCli;
    private int total;

    public Invoice() : base() { }
    public Invoice(int id, DateTime createdDate, int idCli, int total)
    {
        this.id = id;
        this.createdDate = createdDate;
        this.idCli = idCli;
        this.total = total;
    }

    public int Id { get => id; set => id = value; }
    public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
    public int IdCli { get => idCli; set => idCli = value; }
    public int Total { get => total; set => total = value; }
}
