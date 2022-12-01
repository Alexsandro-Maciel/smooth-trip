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
    public partial class frmVerificarEmail : Window
    {
        string nomeUsuario1 = "";
        string codigo1 = "";

        public frmVerificarEmail(string nomeUsuario, string codigo)
        {
            InitializeComponent();

            nomeUsuario1 = nomeUsuario;
            codigo1 = codigo;
        }

        private void Voltar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void VerificarEmail(object sender, MouseButtonEventArgs e)
        {
            if (boxCodigo.Text != "")
            {
                if (boxCodigo.Text == codigo1)
                {
                    IrParaFrmAlterarSenha();
                    Close();
                }

                else
                {
                    IrParaFrmMensagemErro("O código está incorreto!");
                }
            }

            else
            {
                IrParaFrmMensagemAvisoOK("Preencha todos os campos!");
            }
        }

        private void IrParaFrmAlterarSenha()
        {
            frmAlterarSenha frmAlterarSenha = new frmAlterarSenha(nomeUsuario1);
            frmAlterarSenha.Show();
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

    }
}
