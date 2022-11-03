using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConsultasCarga
{
    public static bool InserirProduto(string nome, string descricao, string fabricante, int quantidade)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                INSERT INTO Produto (nome, descricao, qtd, fabricante) 
                VALUES (@nome, @descricao, @qtd, @fabricante)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@descricao", descricao);
            comando.Parameters.AddWithValue("@qtd", quantidade);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            var leitura = comando.ExecuteReader();
            foiInserido = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiInserido;
    }

    public static bool ExcluirProduto(int id)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiExcluido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                DELETE FROM Produto WHERE id = @id;";
            comando.Parameters.AddWithValue("@id", id);
            var leitura = comando.ExecuteReader();
            foiExcluido = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiExcluido;
    }

    public static bool AlterarProduto(int id, string nome, string descricao, string fabricante, int quantidade)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAtualizado = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                UPDATE Produto 
                SET nome = @nome, descricao = @descricao, fabricante = @fabricante, qtd = @quantidade
                WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@descricao", descricao);
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            var leitura = comando.ExecuteReader();
            foiAtualizado = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return foiAtualizado;
    }

    public static List<carga> ObterTodosProdutos()
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        List<carga> listaDeProdutos = new List<carga>();

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Produto";
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                carga carga = new carga();
                carga.Id = leitura.GetInt32("id");
                carga.Endereco_Destino = leitura.GetString("nome");
                carga.Endereco_Origem = leitura.GetString("descricao");
                carga.Quantidade_Animais = leitura.GetString("fabricante");
                carga.Tipo_Caminhao = leitura.GetString("qtd");
                carga.Temperatura = (float)leitura.GetDecimal("temperatura");

                listaDeProdutos.Add(carga);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return listaDeProdutos;
    }
}