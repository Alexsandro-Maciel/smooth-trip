using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConexaoBD
{
    public static MySqlConnectionStringBuilder Connection
    {
        get
        {
            return new MySqlConnectionStringBuilder
            {
                Server = "db4free.net",
                UserID = "alexsandro",
                Password = "dbNovicAae180@",
                Database = "smooth_trip"
            };
        }

        private set { }
    }
}