﻿using System;
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
    public partial class frmCadastro : Window
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void IrParaFrmLogin()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            Close();
        }

        private void VoltarParaFrmLogin(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmLogin();
        }

        private void VerSenha(object sender, MouseButtonEventArgs e)
        {
            boxSenhaEscondida.Visibility = Visibility.Hidden;
            boxSenhaVisivel.Visibility = Visibility.Visible;

            imgVerSenha.Visibility = Visibility.Hidden;
            imgEsconderSenha.Visibility = Visibility.Visible;

            boxSenhaVisivel.Text = boxSenhaEscondida.Password.ToString();
        }

        private void EsconderSenha(object sender, MouseButtonEventArgs e)
        {
            boxSenhaEscondida.Visibility = Visibility.Visible;
            boxSenhaVisivel.Visibility = Visibility.Hidden;

            imgEsconderSenha.Visibility = Visibility.Hidden;
            imgVerSenha.Visibility = Visibility.Visible;

            boxSenhaEscondida.Password = boxSenhaVisivel.Text.ToString();
        }

        private void VerConfirmarSenha(object sender, MouseButtonEventArgs e)
        {
            boxConfirmarSenhaEscondida.Visibility = Visibility.Hidden;
            boxConfirmarSenhaVisivel.Visibility = Visibility.Visible;

            imgVerConfirmarSenha.Visibility = Visibility.Hidden;
            imgEsconderConfirmarSenha.Visibility = Visibility.Visible;

            boxConfirmarSenhaVisivel.Text = boxSenhaEscondida.Password.ToString();
        }

        private void EsconderConfirmarSenha(object sender, MouseButtonEventArgs e)
        {
            boxConfirmarSenhaEscondida.Visibility = Visibility.Visible;
            boxConfirmarSenhaVisivel.Visibility = Visibility.Hidden;

            imgEsconderConfirmarSenha.Visibility = Visibility.Hidden;
            imgVerConfirmarSenha.Visibility = Visibility.Visible;

            boxConfirmarSenhaEscondida.Password = boxSenhaVisivel.Text.ToString();
        }

        private void Cadastrar(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmLogin();
        }
    }
}
