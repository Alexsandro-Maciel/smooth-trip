using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class cUsuario
{
    public static Usuario ObterUsuarioPeloNomeSenha(string nomeUsuario, string senha)
    {
        return ConsultasUsuario.ObterUsuarioPeloNomeSenha(nomeUsuario, senha);
    }

    public static bool VerificarUsuarioExistente(string nomeUsuario)
    {
        return ConsultasUsuario.VerificarUsuarioExistente(nomeUsuario);
    }

    public static bool NovoUsuario(string nomeUsuario, string senha, string email, string tipoUsuario)
    {
        return ConsultasUsuario.NovoUsuario(nomeUsuario, senha, email, tipoUsuario);
    }
}
