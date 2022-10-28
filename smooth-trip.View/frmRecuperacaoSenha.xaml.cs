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
    public partial class frmRecuperacaoSenha : Window
    {
        public frmRecuperacaoSenha()
        {
            InitializeComponent();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void VoltarParaFrmLogin(object sender, MouseButtonEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Close();
        }

        private void IrParaFrmVerificarEmail()
        {
            frmVerificarEmail frmVerificarEmail = new frmVerificarEmail();
            frmVerificarEmail.Show();
            Close();
        }

        private void AvancarRecuperacaoSenha(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmVerificarEmail();
        }
    }
}
