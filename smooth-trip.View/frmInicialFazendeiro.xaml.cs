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
        Usuario usuario1 = null;
        public frmInicialFazendeiro(Usuario usuario)
        {
            InitializeComponent();

            usuario1 = usuario;
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void IrParaFrmSobreNos(object sender, MouseButtonEventArgs e)
        {
            frmSobreNos frmSobreNos = new frmSobreNos();
            frmSobreNos.Show();
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
            txtCadastrarMotorista.Visibility = Visibility.Visible;
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
            txtCadastrarMotorista.Visibility = Visibility.Hidden;
            txtSair.Visibility = Visibility.Hidden;
            imgLogoPreta.Visibility = Visibility.Hidden;

        }

        private void IrParaFrmNovasCargas(object sender, MouseButtonEventArgs e)
        {
            frmNovasCargas frmNovasCargas = new frmNovasCargas(usuario1);
            frmNovasCargas.Show();
            Close();
        }

        private void IrParaFrmMinhasCargas(object sender, MouseButtonEventArgs e)
        {
            frmMinhasCargas frmMinhasCargas = new frmMinhasCargas(usuario1);
            frmMinhasCargas.Show();
            Close();
        }

        private void IrParaFrmConfirmarSenha(string comando)
        {
            frmConfirmarSenha frmConfirmarSenha = new frmConfirmarSenha(usuario1, comando);
            frmConfirmarSenha.Show();
            Close();
        }

        private void IrParaFrmCadastroMotorista(object sender, MouseButtonEventArgs e)
        {
            frmCadastroMotorista frmCadastroMotorista = new frmCadastroMotorista();
            frmCadastroMotorista.Show();
        }

        private void RealizarLogout(object sender, MouseButtonEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Close();
        }

        private void AlterarPerfil(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmConfirmarSenha("Alterar");
        }

        private void ExcluirPerfil(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmConfirmarSenha("Excluir");
        }
    }
}
