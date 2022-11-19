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
    public partial class frmInicialFazendeiro : Window
    {
        public frmInicialFazendeiro()
        {
            InitializeComponent();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void IrParaFrmSobreNos(object sender, MouseButtonEventArgs e)
        {
            frmSobreNos frmSobreNos = new frmSobreNos();
            frmSobreNos.Show();
            Close();
        }

        private void AbrirMenu(object sender, MouseButtonEventArgs e)
        {
            retMenu.Visibility = Visibility.Visible;
            txtMenu.Visibility = Visibility.Visible;
            imgVoltar.Visibility = Visibility.Visible;
            txtNovasCargas.Visibility = Visibility.Visible;
            txtMinhasCargas.Visibility = Visibility.Visible;
            txtAlterarPerfil.Visibility = Visibility.Visible;
            txtExcluirPerfil.Visibility = Visibility.Visible;
            txtSair.Visibility = Visibility.Visible;
            imgLogoPreta.Visibility = Visibility.Visible;
        }

        private void VoltarMenu(object sender, MouseButtonEventArgs e)
        {
            retMenu.Visibility = Visibility.Hidden;
            txtMenu.Visibility = Visibility.Hidden;
            imgVoltar.Visibility = Visibility.Hidden;
            txtNovasCargas.Visibility = Visibility.Hidden;
            txtMinhasCargas.Visibility = Visibility.Hidden;
            txtAlterarPerfil.Visibility = Visibility.Hidden;
            txtExcluirPerfil.Visibility = Visibility.Hidden;
            txtSair.Visibility = Visibility.Hidden;
            imgLogoPreta.Visibility = Visibility.Hidden;

        }

        private void IrParaFrmNovasCargas(object sender, MouseButtonEventArgs e)
        {
            frmNovasCargas frmNovasCargas = new frmNovasCargas();
            frmNovasCargas.Show();
            Close();
        }

        private void IrParaFrmMinhasCargas(object sender, MouseButtonEventArgs e)
        {
            frmMinhasCargas frmMinhasCargas = new frmMinhasCargas();
            frmMinhasCargas.Show();
            Close();
        }

        private void IrParaFrmConfirmarSenha(object sender, MouseButtonEventArgs e)
        {
            frmConfirmarSenha frmConfirmarSenha = new frmConfirmarSenha();
            frmConfirmarSenha.Show();
            Close();
        }

        private void IrParaFrmCadastroMotorista(object sender, MouseButtonEventArgs e)
        {
            frmCadastroMotorista frmCadastroMotorista = new frmCadastroMotorista();
            frmCadastroMotorista.Show();
            Close();
        }

        private void RealizarLogout(object sender, MouseButtonEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Close();
        }

    }
}
