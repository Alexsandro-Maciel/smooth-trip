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
    public partial class frmCadastroFazendeiro : Window
    {
        public frmCadastroFazendeiro()
        {
            InitializeComponent();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void IrParaFrmLogin()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Close();
        }

        private void VoltarParaFrmLogin(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmLogin();
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

        private void Cadastrar(object sender, MouseButtonEventArgs e)
        {
            if (VerificarCampos() == true)
            {
                if (boxSenhaEscondida.Password == boxConfirmarSenhaEscondida.Password)
                {
                    string nomeUsuario = boxUsuario.Text;
                    string email = boxEmail.Text;
                    string senha = boxSenhaEscondida.Password;
                    string tipoUsuario = "Fazendeiro";

                    if (VerificarSenhaValida(senha) == true)
                    {
                        if (cUsuario.VerificarUsuarioExistente(nomeUsuario) == true)
                        {
                            IrParaFrmMensagemErro("Esse usuario já está em uso!");
                        }
                        
                        else
                        {
                            if (cUsuario.NovoUsuario(nomeUsuario, senha, email, tipoUsuario) == true)
                            {
                                IrParaFrmLogin();
                                IrParaFrmMensagemInformacao("Usuário cadastrado com sucesso!");
                            }

                            else
                            {
                                IrParaFrmMensagemErro("Não foi possível cadastrar, tente novamente!");
                            }
                        }
                    }

                    else
                    {
                        IrParaFrmMensagemErro("A senha não cumpre os requisitos mínimos!");
                    }
                }

                else
                {
                    IrParaFrmMensagemErro("Os campos de senha estão diferentes!");
                }

            }

            else
            {
                IrParaFrmMensagemAvisoOK("Preencha todos os campos!");
            }
        }

        private bool VerificarCampos()
        {
            return boxUsuario.Text != "" && boxEmail.Text != "" && boxSenhaEscondida.Password != "" 
                   && boxConfirmarSenhaEscondida.Password != "" || boxUsuario.Text != "" && boxEmail.Text != ""
                   && boxSenhaVisivel.Text != "" && boxConfirmarSenhaVisivel.Text != "" ? true : false;
        }

        private bool VerificarSenhaValida(string senha)
        {
            string especiais = "!@#$%¨&*()_+-=}{´`ªº][^~|?,<>/°";
            string letras = "qwertyuiopasdfghjklçzxcvbnm";
            string maiusculas = letras.ToUpper();
            string numeros = "1234567890";
            int tamanhoMinimo = 8;

            bool isNumeroValidos = false;
            bool isLetrasValidas = false;
            bool isMaiusculas = false;
            bool isCaracteresEspeciaisValidos = false;
            bool isTamanhoMinimoValido = false;

            if (senha.Length >= tamanhoMinimo)
            {
                isTamanhoMinimoValido = true;
                for (int i = 0; i < senha.Length; i++)
                {
                    if (isNumeroValidos == false)
                    {
                        foreach (char c in numeros)
                        {
                            if (c == senha[i])
                            {
                                isNumeroValidos = true;
                                break;
                            }
                        }
                    }

                    if (isLetrasValidas == false)
                    {
                        foreach (char c in letras)
                        {
                            if (c.ToString() == senha[i].ToString())
                            {
                                isLetrasValidas = true;
                                break;
                            }
                        }
                    }
                    if (isMaiusculas == false)
                    {
                        foreach (char c in maiusculas)
                        {
                            if (c.ToString() == senha[i].ToString())
                            {
                                isMaiusculas = true;
                                break;
                            }
                        }
                    }

                    if (isCaracteresEspeciaisValidos == false)
                    {
                        foreach (char c in especiais)
                        {
                            if (c == senha[i])
                            {
                                isCaracteresEspeciaisValidos = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (isNumeroValidos == true && isLetrasValidas == true && isCaracteresEspeciaisValidos == true && isTamanhoMinimoValido == true && isMaiusculas == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void IrParaFrmMensagemInformacao(string mensagem)
        {
            frmMensagemInformacao frmMensagemInformacao = new frmMensagemInformacao(mensagem);
            frmMensagemInformacao.Show();
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
