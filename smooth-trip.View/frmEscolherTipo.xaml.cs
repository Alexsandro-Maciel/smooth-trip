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
    public partial class frmEscolherTipo : Window
    {
        public frmEscolherTipo()
        {
            InitializeComponent();

            cbTipoUsuario.Items.Add("Motorista");
            cbTipoUsuario.Items.Add("Fazendeiro");
        }

        private void VoltarParaFrmLogin(object sender, MouseButtonEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Close();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ConfirmarTipoUsuario(object sender, MouseButtonEventArgs e)
        {
            if(cbTipoUsuario.Text == "Motorista")
            {
                IrParaFrmMensagemInformacao("Por favor contate o fazendeiro!");
            }

            else
            {
                IrParaFrmCadastrarFazendeiro();
            }
        }

        private void IrParaFrmMensagemInformacao(string mensagem)
        {
            frmMensagemInformacao frmMensagemInformacao = new frmMensagemInformacao(mensagem);
            frmMensagemInformacao.Show();
        }

        private void IrParaFrmCadastrarFazendeiro()
        {
            frmCadastroFazendeiro frmCadastroFazendeiro = new frmCadastroFazendeiro();
            frmCadastroFazendeiro.Show();
            Close();
        }
    }
}
