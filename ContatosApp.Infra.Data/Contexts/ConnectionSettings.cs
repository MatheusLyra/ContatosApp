using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Infra.Data.Contexts
{
    public class ConnectionSettings
    {
        public static string ConnectionString
        {
            get => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDContatosApp;Integrated Security=True;";
        }
    }
}
