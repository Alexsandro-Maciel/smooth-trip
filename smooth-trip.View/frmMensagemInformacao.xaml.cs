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
    public partial class frmMensagemInformacao : Window
    {
        public frmMensagemInformacao(string mensagem)
        {
            InitializeComponent();

            txtMensagem.Text = mensagem;
        }

        private void OK(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
