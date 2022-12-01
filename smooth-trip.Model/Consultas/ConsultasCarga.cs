using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConsultasCarga
{
    public static bool NovaCarga(Carga carga)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"INSERT INTO Carga (Endereco_Destino, Endereco_Origem, Quantidade_Animais, 
                                    Tipo_Caminhao, Temperatura, Nivel_Agua, Nivel_Comida, Umidade, Data_Entrega, 
                                    Data_Saida, Id_Fazendeiro_Remetente, Id_Fazendeiro_Destinatario, Id_Motorista) 
                                    VALUES (@Endereco_Destino, @Endereco_Origem, @Quantidade_Animais, @Tipo_Caminhao,
                                    @Temperatura, @Nivel_Agua, @Nivel_Comida, @Umidade, @Data_Entrega, @Data_Saida, 
                                    @Id_Fazendeiro_Remetente, @Id_Fazendeiro_Destinatario, @Id_Motorista)";

            comando.Parameters.AddWithValue("@Endereco_Destino", carga.Endereco_Destino);
            comando.Parameters.AddWithValue("@Endereco_Origem", carga.Endereco_Origem);
            comando.Parameters.AddWithValue("@Quantidade_Animais", carga.Quantidade_Animais);
            comando.Parameters.AddWithValue("@Tipo_Caminhao", carga.Tipo_Caminhao);
            comando.Parameters.AddWithValue("@Temperatura", 0);
            comando.Parameters.AddWithValue("@Nivel_Agua", 0);
            comando.Parameters.AddWithValue("@Nivel_Comida", 0);
            comando.Parameters.AddWithValue("@Umidade", 0);
            comando.Parameters.AddWithValue("@Data_Entrega", carga.Data_Entrega);
            comando.Parameters.AddWithValue("@Data_Saida", carga.Data_Saida);
            comando.Parameters.AddWithValue("@Id_Fazendeiro_Remetente", carga.Id_Fazendeiro_Remetente);
            comando.Parameters.AddWithValue("@Id_Fazendeiro_Destinatario", carga.Id_Fazendeiro_Destinatario);
            comando.Parameters.AddWithValue("@Id_Motorista", carga.Id_Motorista);

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

    public static bool AtualizarCarga(Carga carga)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAlterado = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"update Carga 
                                    set Endereco_Destino = @Endereco_Destino, Endereco_Origem = @Endereco_Origem, 
                                    Quantidade_Animais = @Quantidade_Animais, Tipo_Caminhao = @Tipo_Caminhao, 
                                    Data_Entrega = @Data_Entrega, Id_Fazendeiro_Remetente = @Id_Fazendeiro_Remetente, 
                                    Id_Fazendeiro_Destinatario = @Id_Fazendeiro_Destinatario, 
                                    Id_Motorista = @Id_Motorista 
                                    where Id = @id";
                             
            comando.Parameters.AddWithValue("@Endereco_Destino", carga.Endereco_Destino);
            comando.Parameters.AddWithValue("@Endereco_Origem", carga.Endereco_Origem);
            comando.Parameters.AddWithValue("@Quantidade_Animais", carga.Quantidade_Animais);
            comando.Parameters.AddWithValue("@Tipo_Caminhao", carga.Tipo_Caminhao);
            comando.Parameters.AddWithValue("@Data_Entrega", carga.Data_Entrega);
            comando.Parameters.AddWithValue("@Id_Fazendeiro_Remetente", carga.Id_Fazendeiro_Remetente);
            comando.Parameters.AddWithValue("@Id_Fazendeiro_Destinatario", carga.Id_Fazendeiro_Destinatario);
            comando.Parameters.AddWithValue("@Id_Motorista", carga.Id_Motorista);

            var leitura = comando.ExecuteReader();
            foiAlterado = true;
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
        return foiAlterado;
    }

    public static List<Carga> ObterTodasCargas()
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        List<Carga> listaDeProdutos = new List<Carga>();

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"SELECT * FROM Cargas where Id_Fazendeiro_Destinatário = @idUsuarioLogado or Id_Fazendeiro_Destinatário = @idUsuarioLogado or Id_Motorista = @idUsuarioLogado ";
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                Carga carga = new Carga();
                carga.Id = leitura.GetInt32("id");
                carga.Endereco_Destino = leitura.GetString("nome");
                carga.Endereco_Origem = leitura.GetString("descricao");
                carga.Quantidade_Animais = leitura.GetInt32("fabricante");
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

    public static bool ExcluirCarga(int id)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiExcluido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"delete from Carga where Id = @id";

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
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return foiExcluido;
    }

    public static Carga ObterDadosMonitoramento(int id)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        Carga carga = null;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"SELECT Temperatura, Umidade, Nivel_Comida, Nivel_Agua FROM Cargas where Id = @id";

            comando.Parameters.AddWithValue("@id", id);
            var leitura = comando.ExecuteReader();

            while (leitura.Read())
            {
                carga = new Carga();
                carga.Temperatura = (float)leitura.GetDecimal("Temperatura");
                carga.Umidade = (float)leitura.GetDecimal("Umidade");
                carga.Nivel_Comida = (float)leitura.GetDecimal("Nivel_Comida");
                carga.Nivel_Agua = (float)leitura.GetDecimal("Nivel_Agua");
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
        return carga;
    }
}