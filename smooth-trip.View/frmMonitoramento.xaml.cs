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
    public partial class frmMonitoramento : Window
    {
        Carga carga1 = null;

        public frmMonitoramento(Carga carga)
        {
            InitializeComponent();

            carga1 = carga;

            ApresentarDadosMonitoramento();
        }

        private void VoltarParaFrmInicial(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void IrParaFrmAlterarCarga(object sender, MouseButtonEventArgs e)
        {
            frmAlterarCarga frmAlterarCarga = new frmAlterarCarga(carga1);
            frmAlterarCarga.Show();
            Close();
        }
 
        private void IrParaFrmExcluirCarga(object sender, MouseButtonEventArgs e)
        {
            frmDeletarCarga frmDeletarCarga = new frmDeletarCarga(carga1.Id);
            frmDeletarCarga.Show();
            Close();
        }

        private void AtualizarDadosMonitoramento(object sender, MouseButtonEventArgs e)
        {
            ApresentarDadosMonitoramento();
        }

        private void ApresentarDadosMonitoramento()
        {
            Carga carga = cCarga.ObterDadosMonitoramento(carga1.Id);

            txtCodigoCarga.Text = $"Código da Carga: 0{carga1.Id}";
            txtTemperatura.Text = $"Temperatura: {carga.Temperatura}ºC";
            txtUmidade.Text = $"Umidade: {carga.Umidade}%";
            txtNivelAgua.Text = $"Nivel de Água: {carga.Nivel_Agua}%";
            txtNivelComida.Text = $"Nivel de Comida: {carga.Nivel_Comida}%";
        }
    }
}
