using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerreteriaConsoleApp.Entities;

namespace FerreteriaConsoleApp.Querys;

public class QClient
{
    public static List<Client> GetClients()
    {
        List<Client> ClientList = new List<Client>()
    {
        new Client(1098739851, "William", "william@correo.com"),
        new Client(1099220651, "Natalia", "Natalia@correo.com"),
        new Client(1097521547, "Samir", "Samir@correo.com"),
        new Client(1098885147, "Nancy", "Nancy@correo.com"),
        new Client(1095587412, "Wilson", "Wilson@correo.com"),
        new Client(1099823365, "Pedro", "Pedro@correo.com"),
        new Client(1094123654, "Derly", "Derly@correo.com")
    };
        return ClientList;
    }
}
