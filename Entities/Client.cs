using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaConsoleApp.Entities;

public class Client
{
    private int id;
    private string name;
    private string email;

    public Client() : base()
    {
    }
    public Client(int nid, string nname, string nemail)
    {
        this.id = nid;
        this.name = nname;
        this.email = nemail;
    }

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Email { get => email; set => email = value; }
}
