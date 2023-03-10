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
    public partial class frmMensagemAvisoSimNao : Window
    {
        string tabela1 = "";
        int id1 = 0;
        Usuario usuario1 = null; 

        public frmMensagemAvisoSimNao(string mensagem, string tabela, Usuario usuario, int id)
        {
            InitializeComponent();

            txtMensagem.Text = mensagem;
            tabela1 = tabela;
            id1 = id;
            usuario1 = usuario;
        }

        private void Confirmar(object sender, MouseButtonEventArgs e)
        {
            if (tabela1 == "Usuario")
            {
                if (cUsuario.ExcluirUsuario(usuario1.Id) == true)
                {
                    IrParaFrmLogin();
                    IrParaFrmMensagemInformacao("Perfil excluído com sucesso!");
                }

                else
                {
                    IrParaFrmInicial();
                    IrParaFrmMensagemErro("Não foi possível excluir!");
                }
            }
            
            else
            {
                if (cCarga.ExcluirCarga(id1) == true)
                {
                    IrParaFrmMensagemInformacao("Carga excluída com sucesso!");
                    Close();
                }

                else
                {
                    IrParaFrmMensagemErro("Não foi possível excluir!");
                }
            }
        }

        private void Cancelar(object sender, MouseButtonEventArgs e)
        {
            if (tabela1 == "Usuario")
            {
                IrParaFrmInicial();
            }

            Close();
        }

        private void IrParaFrmMensagemErro(string mensagem)
        {
            frmMensagemErro frmMensagemErro = new frmMensagemErro(mensagem);
            frmMensagemErro.Show();
            Close();
        }

        private void IrParaFrmMensagemInformacao(string mensagem)
        {
            frmMensagemInformacao frmMensagemInformacao = new frmMensagemInformacao(mensagem);
            frmMensagemInformacao.Show();
            Close();
        }

        private void IrParaFrmLogin()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
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
    }
}
