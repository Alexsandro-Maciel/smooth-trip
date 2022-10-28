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
    public partial class frmVerificarEmail : Window
    {
        public frmVerificarEmail()
        {
            InitializeComponent();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void VoltarParaFrmRecuperacaoSenha(object sender, MouseButtonEventArgs e)
        {
            frmRecuperacaoSenha frmRecuperacaoSenha = new frmRecuperacaoSenha();
            frmRecuperacaoSenha.Show();
            Close();
        }

        private void VerificarEmail(object sender, MouseButtonEventArgs e)
        {
            frmAlterarSenha frmAlterarSenha = new frmAlterarSenha();
            frmAlterarSenha.Show();
            Close();
        }
    }
}
