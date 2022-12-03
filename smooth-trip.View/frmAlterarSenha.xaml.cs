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
    public partial class frmAlterarSenha : Window
    {
        string nomeUsuario1 = "";
        public frmAlterarSenha(string nomeUsuario)
        {
            InitializeComponent();

            nomeUsuario1 = nomeUsuario;
        }

        private void Voltar(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmLogin();
        }

        private void AtualizarSenha(object sender, MouseButtonEventArgs e)
        {
            if (boxSenhaEscondida.Password != "" && boxConfirmarSenhaEscondida.Password != "")
            {
                if (boxSenhaEscondida.Password == boxConfirmarSenhaEscondida.Password)
                {
                    if (cUsuario.AlterarSenha(nomeUsuario1, boxSenhaEscondida.Password) == true)
                    {
                        IrParaFrmLogin();
                        Close();
                        IrParaFrmMensagemInformacao("Senha Alterada com sucesso!");
                    }

                    else
                    {
                        IrParaFrmMensagemErro("Não foi possivel alterar a senha!");
                    }
                }

                else
                {
                    IrParaFrmMensagemAvisoOK("Os campos não estão iguais!");
                }
            }

            else
            {
                IrParaFrmMensagemAvisoOK("Preencha todos os campos!");
            }
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

        private void VerConfirmarSenha(object sender, MouseButtonEventArgs e)
        {
            boxConfirmarSenhaEscondida.Visibility = Visibility.Hidden;
            boxConfirmarSenhaVisivel.Visibility = Visibility.Visible;

            imgVerConfirmarSenha.Visibility = Visibility.Hidden;
            imgEsconderConfirmarSenha.Visibility = Visibility.Visible;

            boxConfirmarSenhaVisivel.Text = boxSenhaEscondida.Password.ToString();
        }

        private void EsconderConfirmarSenha(object sender, MouseButtonEventArgs e)
        {
            boxConfirmarSenhaEscondida.Visibility = Visibility.Visible;
            boxConfirmarSenhaVisivel.Visibility = Visibility.Hidden;

            imgEsconderConfirmarSenha.Visibility = Visibility.Hidden;
            imgVerConfirmarSenha.Visibility = Visibility.Visible;

            boxConfirmarSenhaEscondida.Password = boxSenhaVisivel.Text.ToString();
        }

        private void IrParaFrmMensagemErro(string mensagem)
        {
            frmMensagemErro frmMensagemErro = new frmMensagemErro(mensagem);
            frmMensagemErro.Show();
        }

        private void IrParaFrmMensagemAvisoOK(string mensagem)
        {
            frmMensagemAvisoOK frmMensagemAvisoOK = new frmMensagemAvisoOK(mensagem);
            frmMensagemAvisoOK.Show();
        }

        private void IrParaFrmMensagemInformacao(string mensagem)
        {
            frmMensagemInformacao frmMensagemInformacao = new frmMensagemInformacao(mensagem);
            frmMensagemInformacao.Show();
        }

        private void IrParaFrmLogin()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

    }
}
