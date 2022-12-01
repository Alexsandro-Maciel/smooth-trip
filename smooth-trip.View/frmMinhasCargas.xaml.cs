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
        public frmMinhasCargas(Usuario usuario)
        {
            InitializeComponent();

            usuario1 = usuario;
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
    }
}
