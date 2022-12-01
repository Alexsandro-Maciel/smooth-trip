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
    public partial class frmDeletarUsuario : Window
    {
        Usuario usuario1 = null;

        public frmDeletarUsuario(Usuario usuario)
        {
            InitializeComponent();

            usuario1 = usuario;
        }

        private void VoltarParaFrmInicial(object sender, MouseButtonEventArgs e)
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

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void DeletarUsuario(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmMensagemAvisoSimNao("Tem certeza que deseja excluir o perfil?", "Usuario");
            Close();
        }

        private void IrParaFrmInicialFazendeiro(Usuario usuario1)
        {
            frmInicialFazendeiro frmInicialFazendeiro = new frmInicialFazendeiro(usuario1);
            frmInicialFazendeiro.Show();
            Close();
        }

        private void IrParaFrmInicialMotorista(Usuario usuario1)
        {
            frmInicialMotorista frmInicialMotorista = new frmInicialMotorista(usuario1);
            frmInicialMotorista.Show();
            Close();
        }

        private void IrParaFrmMensagemAvisoSimNao(string mensagem, string tabela)
        {
            frmMensagemAvisoSimNao frmMensagemAvisoSimNao = new frmMensagemAvisoSimNao(mensagem, tabela, usuario1, usuario1.Id);
            frmMensagemAvisoSimNao.Show();
        }

    }
}
