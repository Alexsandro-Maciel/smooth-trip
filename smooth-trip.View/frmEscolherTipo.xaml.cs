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
    public partial class frmEscolherTipo : Window
    {
        public frmEscolherTipo()
        {
            InitializeComponent();
        }

        private void VoltarParaFrmLogin(object sender, MouseButtonEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Close();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ConfirmarTipoUsuario(object sender, MouseButtonEventArgs e)
        {
            frmCadastroFazendeiro frmCadastroFazendeiro = new frmCadastroFazendeiro();
            frmCadastroFazendeiro.Show();
            Close();
        }
    }
}
