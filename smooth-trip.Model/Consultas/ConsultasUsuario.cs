﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public static class ConsultasUsuario
{
    public static bool VerificarUsuarioExistente(string nomeUsuario)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool usuarioExiste = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where Nome_Usuario = @nomeUsuario";
            comando.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);
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

    public static bool NovoUsuario(string nomeUsuario, string senha, string email, string tipoUsuario)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;
        string senhaCriptografada = Criptografia.CriptografarMD5(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Insert Into Usuario (Nome_Usuario, Senha, Email, Tipo_Usuario) Values (@nomeUsuario, @senha, @email, @tipoUsuario)";
            comando.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);

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

    public static Usuario ObterUsuarioPeloEmailSenha(string nomeUsuario, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        Usuario usuario = null;
        string senhaCriptografada = Criptografia.CriptografarMD5(senha);

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where Nome_Usuario = @nomeUsuario and Senha = @senha";
            comando.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);
            comando.Parameters.AddWithValue("@senha", senhaCriptografada);
            var leitura = comando.ExecuteReader();

            while (leitura.Read())
            {
                usuario = new Usuario();
                usuario.Id = leitura.GetInt32("Id");
                usuario.Nome_Usuario = leitura.GetString("Nome_Usuario");
                usuario.Senha = leitura.GetString("Senha");
                usuario.Email = leitura.GetString("Email");
                usuario.Tipo_Usuario = leitura.GetString("Tipo_Usuario");

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