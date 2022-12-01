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
    public partial class frmDeletarCarga : Window
    {
        int id1 = 0;

        public frmDeletarCarga(int id)
        {
            InitializeComponent();

            id1 = id;
        }

        private void VoltarParaFrmInicial(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void DeletarCarga(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmMensagemAvisoSimNao("Tem certeza que deseja excluir a carga?", "Carga", id1);
            Close();
        }

        private void IrParaFrmMensagemAvisoSimNao(string mensagem, string tabela, int id )
        {
            frmMensagemAvisoSimNao frmMensagemAvisoSimNao = new frmMensagemAvisoSimNao(mensagem, tabela, id);
            frmMensagemAvisoSimNao.Show();
        }


    }
}
