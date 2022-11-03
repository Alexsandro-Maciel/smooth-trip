using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public static class ConsultasUsuario
{
    public static bool VerificarUsuarioExistente(string email)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool usuarioExiste = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where email = @email";
            comando.Parameters.AddWithValue("@email", email);
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                usuarioExiste = true;
                break;
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        finally
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return usuarioExiste;
    }

    public static bool NovoUsuario(string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;
        string senhaCriptografada = Criptografia.CriptografarMD5(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Insert Into Usuario (email, senha) Values (@email, @senha)";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
            var leitura = comando.ExecuteReader();
            foiInserido = true;
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        finally
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return foiInserido;
    }

    public static usuario ObterUsuarioPeloEmailSenha(string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        usuario usuario = null;
        string senhaCriptografada = Criptografia.CriptografarMD5(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where email = @email and senha = @senha";
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
            comando.Parameters.AddWithValue("@email", email);
            var leitura = comando.ExecuteReader();

            while (leitura.Read())
            {
                usuario = new usuario();
                usuario.Id = leitura.GetInt32("id");
                usuario.Nome_Usuario = leitura.GetString("nome_usuario");
                usuario.Senha = leitura.GetString("senha");
                usuario.Email = leitura.GetString("email");
                usuario.Tipo_Usuario = leitura.GetString("tipo_usuario");

                break;
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        finally
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return usuario;
    }
}
