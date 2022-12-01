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

    public static bool AtualizarUsuario(int id, string nomeUsuario, string senha, string email)
    {
        return ConsultasUsuario.AtualizarUsuario(id, nomeUsuario, senha, email);
    }

    public static bool ExcluirUsuario(int id)
    {
        return ConsultasUsuario.ExcluirUsuario(id);
    }

    public static List<string> ObterNomesFazendeiros()
    {
        return ConsultasUsuario.ObterNomesFazendeiros();
    }

    public static List<string> ObterNomesMotoristas()
    {
        return ConsultasUsuario.ObterNomesMotoristas();
    }

    public static int ObterIdUsuario(string nomeUsuario)
    {
        return ConsultasUsuario.ObterIdUsuario(nomeUsuario);
    }

    public static bool AlterarSenha(string nomeUsuario, string senha)
    {
        return ConsultasUsuario.AlterarSenha(nomeUsuario, senha);
    }

}
