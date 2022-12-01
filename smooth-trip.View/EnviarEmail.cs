using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class EnviarEmails
{
    public static string EnviarEmail(string email, string nomeUsuario)
    {
        Random random = new Random();
        string codigo = random.Next(100000, 1000000).ToString();



        return codigo;
    }
}
