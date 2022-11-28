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
        public string mensagem1 = "";
        public string tabela1 = "";
        public Usuario usuario1 = null;
        public Carga carga1 = null;

        public frmMensagemAvisoSimNao(string mensagem, string tabela, Usuario usuario, Carga carga)
        {
            InitializeComponent();

            mensagem1 = mensagem;
            tabela1 = tabela;
            usuario1 = usuario;
            carga1 = carga;
        }

        private void Confirmar(object sender, MouseButtonEventArgs e)
        {
            if (tabela1 == "Usuario")
            {
                if (cUsuario.ExcluirUsuario(usuario1.Id) == true)
                {
                    IrParaFrmMensagemInformacao("Perfil excluído com sucesso!");
                    IrParaFrmLogin();
                }

                else
                {
                    IrParaFrmMensagemErro("Não foi possível excluir!");
                    IrParaFrmInicial();
                }
            }
            
            else
            {
                if (cCarga.ExcluirCarga(carga1.Id) == true)
                {
                    IrParaFrmMensagemInformacao("Carga excluída com sucesso!");
                    IrParaFrmInicial();
                }

                else
                {
                    IrParaFrmMensagemErro("Não foi possível excluir!");
                    IrParaFrmMonitoramento();
                }
            }
        }

        private void Cancelar(object sender, MouseButtonEventArgs e)
        {
            if (tabela1 == "Usuario")
            {
                IrParaFrmInicial();
            }

            else
            {
                IrParaFrmMonitoramento();
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

        private void IrParaFrmMonitoramento()
        {
            frmMonitoramento frmMonitoramento = new frmMonitoramento();
            frmMonitoramento.Show();
        }

    }
}
