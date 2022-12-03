using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace smooth_trip
{
    public partial class frmMinhasCargas : Window
    {
        Usuario usuario1 = null;

        public class CargaInserida
        {
            public int Cód { get; set; }
            public string Origem { get; set; }
            public string Destino { get; set; }
            public string Destinatário { get; set; }
            public string Remetente { get; set; }
            public string Motorista { get; set; }

        }

        public frmMinhasCargas(Usuario usuario)
        {
            InitializeComponent();

            usuario1 = usuario;

            AtualizaDataGrid();
        }

        private void VoltarParaFrmInicial(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmInicial();
            Close();
        }

        private void IrParaFrmInicial()
        {
            if (usuario1.Tipo_Usuario == "Fazendeiro")
            {
                IrParaFrmInicialFazendeiro(usuario1);
            }

            else
            {
                IrParaFrmInicialMotorista(usuario1);
            }

        }

        private void IrParaFrmInicialFazendeiro(Usuario usuario)
        {
            frmInicialFazendeiro frmInicialFazendeiro = new frmInicialFazendeiro(usuario);
            frmInicialFazendeiro.Show();
        }

        private void IrParaFrmInicialMotorista(Usuario usuario)
        {
            frmInicialMotorista frmInicialMotorista = new frmInicialMotorista(usuario);
            frmInicialMotorista.Show();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void AtualizaDataGrid()
        {
            List<Carga> listaDeCargas = new List<Carga>();
            listaDeCargas = cCarga.ObterTodasCargas(usuario1.Id);
            
            dgvMinhasCargas.ItemsSource = listaDeCargas;
            dgvMinhasCargas.Items.Refresh();
        }

        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {
            Carga carga = (Carga)
            dgvMinhasCargas.SelectedItem;
            Carga carga1 = cCarga.ObterDadosCargaSelecionada(carga.Id);
            IrParaFrmMonitoramento(carga.Id, carga1);
        }

        private void IrParaFrmMonitoramento(int id, Carga carga)
        {
            frmMonitoramento frmMonitoramento = new frmMonitoramento(id, carga);
            frmMonitoramento.Show();
        }
    }
}
