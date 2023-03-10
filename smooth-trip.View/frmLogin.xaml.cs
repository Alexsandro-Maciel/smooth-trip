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

        private void EfetuarLogin(object sender, RoutedEventArgs e)
        {
            if (VerificarCampos() == true)
            {
                string nomeUsuario = boxUsuario.Text;
                string senha = boxSenhaEscondida.Password;

                Usuario usuario = cUsuario.ObterUsuarioPeloNomeSenha(nomeUsuario, senha);

                if (usuario != null)
                {
                    if (usuario.Tipo_Usuario == "Fazendeiro")
                    {
                        IrParaFrmInicialFazendeiro(usuario);
                    }

                    else
                    {
                        IrParaFrmInicialMotorista(usuario);
                    }
                }

                else
                {
                    IrParaFrmMensagemErro("Usuario e/ou senha incorretos!");
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

        private void Cadastrar(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmEscolherTipo();
        }

        private void EsqueceuSenha(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmRecuperacaoSenha();
            Close();
        }

        private void IrParaFrmRecuperacaoSenha()
        {
            frmRecuperacaoSenha frmRecuperacaoSenha = new frmRecuperacaoSenha();
            frmRecuperacaoSenha.Show();
        }

        private void IrParaFrmInicialFazendeiro(Usuario usuario)
        {
            frmInicialFazendeiro frmInicialFazendeiro = new frmInicialFazendeiro(usuario);
            frmInicialFazendeiro.Show();
            Close();
        }

        private void IrParaFrmInicialMotorista(Usuario usuario)
        {
            frmInicialMotorista frmInicialMotorista = new frmInicialMotorista(usuario);
            frmInicialMotorista.Show();
            Close();
        }

        private void IrParaFrmEscolherTipo()
        {
            frmEscolherTipo frmEscolherTipo = new frmEscolherTipo();
            frmEscolherTipo.Show();
            Close();
        }

        private bool VerificarCampos()
        {
            return boxSenhaEscondida.Password != "" && boxUsuario.Text != "" ||
                   boxSenhaVisivel.Text != "" && boxUsuario.Text != "" ? true : false;
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
    }
}
