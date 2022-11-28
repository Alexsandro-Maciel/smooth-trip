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
        Usuario usuario1 = null;
        string comando1 = "";

        public frmConfirmarSenha(Usuario usuario, string comando)
        {
            InitializeComponent();

            usuario1 = usuario;
            comando1 = comando;
        }

        private void VoltarParaFrmInicial(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmInicial();
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
            if (boxConfirmarSenhaEscondida.Password != "" || boxConfirmarSenhaVisivel.Text != "")
            {
                string senhaCriptografada = Criptografia.CriptografarMD5(boxConfirmarSenhaEscondida.Password);

                if (senhaCriptografada == usuario1.Senha)
                {
                    if (comando1 == "Alterar")
                    {
                        IrParaFrmAlterarPerfil();
                    }
                    else
                    {
                        IrParaFrmDeletarUsuario();
                    }
                }

                else
                {
                    IrParaFrmMensagemErro("A senha está incorreta!");
                }
            }

            else
            {
                IrParaFrmMensagemAvisoOK("Preencha todos os campos!");
            }
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
            Close();
        }

        private void IrParaFrmInicialMotorista(Usuario usuario)
        {
            frmInicialMotorista frmInicialMotorista = new frmInicialMotorista(usuario);
            frmInicialMotorista.Show();
            Close();
        }

        private void IrParaFrmAlterarPerfil()
        {
            frmAlterarPerfil frmAlterarPerfil = new frmAlterarPerfil(usuario1);
            frmAlterarPerfil.Show();
            Close();
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

        private void IrParaFrmDeletarUsuario()
        {
            frmDeletarUsuario frmDeletarUsuario = new frmDeletarUsuario(usuario1);
            frmDeletarUsuario.Show();
            Close();
        }
    }
}
