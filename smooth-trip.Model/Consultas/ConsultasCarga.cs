using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConsultasCarga
{
    public static bool InserirCarga(string enderecoDestino, string enderecoOrigem, int quantidadeAnimais,
                                    string tipoCaminhao, float temperatura, float nivelAgua, float nivelComida,
                                    float umidade, string dataEntrega, string dataSaida, int idFazendeiroRemetente, 
                                    int idFazendeiroDestinatario, int idMotorista)
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

            comando.Parameters.AddWithValue("@Endereco_Destino", enderecoDestino);
            comando.Parameters.AddWithValue("@Endereco_Origem", enderecoOrigem);
            comando.Parameters.AddWithValue("@Quantidade_Animais", quantidadeAnimais);
            comando.Parameters.AddWithValue("@Tipo_Caminhao", tipoCaminhao);
            comando.Parameters.AddWithValue("@Temperatura", temperatura);
            comando.Parameters.AddWithValue("@Nivel_Agua", nivelAgua);
            comando.Parameters.AddWithValue("@Nivel_Comida", nivelComida);
            comando.Parameters.AddWithValue("@Umidade", umidade);
            comando.Parameters.AddWithValue("@Data_Entrega", dataEntrega);
            comando.Parameters.AddWithValue("@Data_Saida", dataSaida);
            comando.Parameters.AddWithValue("@Id_Fazendeiro_Remetente", idFazendeiroRemetente);
            comando.Parameters.AddWithValue("@Id_Fazendeiro_Destinatario", idFazendeiroDestinatario);
            comando.Parameters.AddWithValue("@Id_Motorista", idMotorista);

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
        bool foiExcluido = false;
        return foiExcluido;
    }
}