using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class cCarga
{
    public static bool NovaCarga(Carga carga)
    {
        return ConsultasCarga.NovaCarga(carga);
    }

    public static bool AtualizarCarga(Carga carga)
    {
        return ConsultasCarga.AtualizarCarga(carga);
    }

    public static bool ExcluirCarga(int id)
    {
        return ConsultasCarga.ExcluirCarga(id);
    }

    public static Carga ObterDadosMonitoramento(int id)
    {
        return ConsultasCarga.ObterDadosMonitoramento(id);
    }
}
