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
    public partial class frmConfirmarSenha : Window
    {
        public frmConfirmarSenha()
        {
            InitializeComponent();
        }

        private void VoltarParaFrmInicial(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmInicialFazendeiro();
        }

        private void IrParaFrmInicialFazendeiro()
        {
            frmInicialFazendeiro frmInicialFazendeiro = new frmInicialFazendeiro();
            frmInicialFazendeiro.Show();
            Close();
        }

        private void VerConfirmarSenha(object sender, MouseButtonEventArgs e)
        {
            boxConfirmarSenhaEscondida.Visibility = Visibility.Hidden;
            boxConfirmarSenhaVisivel.Visibility = Visibility.Visible;

            imgVerConfirmarSenha.Visibility = Visibility.Hidden;
            imgEsconderConfirmarSenha.Visibility = Visibility.Visible;

            boxConfirmarSenhaVisivel.Text = boxConfirmarSenhaEscondida.Password.ToString();
        }

        private void EsconderConfirmarSenha(object sender, MouseButtonEventArgs e)
        {
            boxConfirmarSenhaEscondida.Visibility = Visibility.Visible;
            boxConfirmarSenhaVisivel.Visibility = Visibility.Hidden;

            imgEsconderConfirmarSenha.Visibility = Visibility.Hidden;
            imgVerConfirmarSenha.Visibility = Visibility.Visible;

            boxConfirmarSenhaEscondida.Password = boxConfirmarSenhaVisivel.Text.ToString();
        }

        private void ConfirmarSenha(object sender, MouseButtonEventArgs e)
        {
            frmAlterarPerfil frmAlterarPerfil = new frmAlterarPerfil();
            frmAlterarPerfil.Show();
            Close();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void IrParaFrmRecuperarSenha(object sender, MouseButtonEventArgs e)
        {
            frmRecuperacaoSenha frmRecuperacaoSenha = new frmRecuperacaoSenha();
            frmRecuperacaoSenha.Show();
            Close();
        }
    }
}
