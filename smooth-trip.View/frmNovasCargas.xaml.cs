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
    public partial class frmNovasCargas : Window
    {
        Usuario usuario = null;
        public frmNovasCargas()
        {
            InitializeComponent();
        }

        private void CadastrarCargas(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmInicialFazendeiro();
        }

        private void VoltarParaFrmInicialFazendeiro(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmInicialFazendeiro();
        }

        private void IrParaFrmInicialFazendeiro()
        {
            frmInicialFazendeiro frmInicialFazendeiro = new frmInicialFazendeiro(usuario);
            frmInicialFazendeiro.Show();
            Close();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
