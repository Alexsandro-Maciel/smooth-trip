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
    public partial class frmRecuperacaoSenha : Window
    {
        string codigo = "000000";
        public frmRecuperacaoSenha()
        {
            InitializeComponent();
        }

        private void Voltar(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmLogin();
        }

        private void IrParaFrmVerificarEmail()
        {
            frmVerificarEmail frmVerificarEmail = new frmVerificarEmail(boxUsuario.Text, codigo);
            frmVerificarEmail.Show();
            Close();
        }

        private void AvancarRecuperacaoSenha(object sender, MouseButtonEventArgs e)
        {
            if (boxEmail.Text != "" && boxUsuario.Text != "")
            {
                codigo = EnviarEmails.EnviarEmail(boxEmail.Text, boxUsuario.Text);
                IrParaFrmVerificarEmail();
                Close();
            }

            else
            {
                IrParaFrmMensagemAvisoOK("Preencha todos os campos!");
            }
        }

        private void IrParaFrmMensagemAvisoOK(string mensagem)
        {
            frmMensagemAvisoOK frmMensagemAvisoOK = new frmMensagemAvisoOK(mensagem);
            frmMensagemAvisoOK.Show();
        }

        private void IrParaFrmLogin()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Close();
        }

    }
}
