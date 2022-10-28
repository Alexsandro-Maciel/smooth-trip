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
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void IrParaFrmCadastro(object sender, MouseButtonEventArgs e)
        {
            frmCadastro frmCadastro = new frmCadastro();
            frmCadastro.Show();
            Close();
        }

        private void IrParaFrmInicialFazendeiro()
        {
            frmInicialFazendeiro frmInicialFazendeiro = new frmInicialFazendeiro();
            frmInicialFazendeiro.Show();
            Close();
        }

        private void EfetuarLogin(object sender, RoutedEventArgs e)
        {
            IrParaFrmInicialFazendeiro();
        }

        private void VerSenha(object sender, MouseButtonEventArgs e)
        {
            boxSenhaEscondida.Visibility = Visibility.Hidden;
            boxSenhaVisivel.Visibility = Visibility.Visible;

            imgVerSenha.Visibility = Visibility.Hidden;
            imgEsconderSenha.Visibility = Visibility.Visible;

            boxSenhaVisivel.Text = boxSenhaEscondida.Password.ToString();
        }

        private void EsconderSenha(object sender, MouseButtonEventArgs e)
        {
            boxSenhaEscondida.Visibility = Visibility.Visible;
            boxSenhaVisivel.Visibility = Visibility.Hidden;

            imgEsconderSenha.Visibility = Visibility.Hidden;
            imgVerSenha.Visibility = Visibility.Visible;

            boxSenhaEscondida.Password = boxSenhaVisivel.Text.ToString();
        }

        private void IrParaFrmRecuperarSenha(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
