using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class carga
{
    public int Id { get; set; }
    public string Endereco_Destino { get; set; }
    public string Endereco_Origem { get; set; }
    public int Quantidade_Animais { get; set; }
    public string Tipo_Caminhao { get; set; }
    public float Temperatura { get; set; }
    public float Nivel_Agua { get; set; }
    public float Nivel_Comida { get; set; }
    public float Umidade { get; set; }
    public string Data_Entrega { get; set; }
    public string Data_Saida { get; set; }
    public int Id_Fazendeiro_Remetente { get; set; }
    public int Id_Fazendeiro_Destinatario { get; set; }
    public int Id_Motorista { get; set; }
}
