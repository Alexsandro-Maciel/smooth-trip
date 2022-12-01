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
        Usuario usuario1 = null;

        public frmNovasCargas(Usuario usuario)
        {
            InitializeComponent();

            usuario1 = usuario;

            Configurar();
        }

        private void Configurar()
        {
            List<string> fazendeiros = new List<string>();
            fazendeiros = cUsuario.ObterNomesFazendeiros();

            List<string> motoristas = new List<string>();
            motoristas = cUsuario.ObterNomesMotoristas();

            cbFazendeiroDestinatario.Items.Add(fazendeiros);
            cbFazendeiroRemetente.Items.Add(fazendeiros);
            cbMotoristaResponsavel.Items.Add(motoristas);

            cbTipoCaminhao.Items.Add("Truck");
            cbTipoCaminhao.Items.Add("Carreta Baixa");
            cbTipoCaminhao.Items.Add("Carreta Alta");
        }

        private void CadastrarCargas(object sender, MouseButtonEventArgs e)
        {
            if (VerificarCampos() == true)
            {
                Carga carga = new Carga();

                carga.Id_Fazendeiro_Destinatario = cUsuario.ObterIdUsuario(cbFazendeiroDestinatario.Text);
                carga.Id_Fazendeiro_Remetente = cUsuario.ObterIdUsuario(cbFazendeiroRemetente.Text);
                carga.Id_Motorista = cUsuario.ObterIdUsuario(cbMotoristaResponsavel.Text);
                carga.Endereco_Destino = boxEnderecoDestino.Text;
                carga.Endereco_Origem = boxEnderecoOrigem.Text;
                carga.Tipo_Caminhao = cbTipoCaminhao.Text;
                carga.Quantidade_Animais = Int32.Parse(cbQuantidadeAnimais.Text);
                carga.Data_Entrega = boxDataEntrega.Text;
                carga.Data_Saida = DateTime.Now.ToString("yyyy-MM-dd");

                if (cCarga.NovaCarga(carga) == true)
                {
                    IrParaFrmInicialFazendeiro();
                    Close();
                    IrParaFrmMensagemInformacao("Carga cadastrada com sucesso!");
                }

                else
                {
                    IrParaFrmMensagemErro("Não foi possível cadastrar!");
                }
            }

            else
            {
                IrParaFrmMensagemAvisoOK("Preencha todos os campos!");
            }
        }

        private void VoltarParaFrmInicialFazendeiro(object sender, MouseButtonEventArgs e)
        {
            IrParaFrmInicialFazendeiro();
        }

        private void IrParaFrmInicialFazendeiro()
        {
            frmInicialFazendeiro frmInicialFazendeiro = new frmInicialFazendeiro(usuario1);
            frmInicialFazendeiro.Show();
            Close();
        }

        private void Fechar(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private bool VerificarCampos()
        {
            return cbFazendeiroDestinatario.Text != "" && cbFazendeiroRemetente.Text != "" 
                   && boxEnderecoDestino.Text != "" && boxEnderecoOrigem.Text != "" 
                   && cbMotoristaResponsavel.Text != "" && cbQuantidadeAnimais.Text != "" 
                   && cbTipoCaminhao.Text != "" && boxDataEntrega.Text != "" ? true : false;
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

        private void IrParaFrmMensagemInformacao(string mensagem)
        {
            frmMensagemInformacao frmMensagemInformacao = new frmMensagemInformacao(mensagem);
            frmMensagemInformacao.Show();
        }

        private void EscolheuCaminhao(object sender, SelectionChangedEventArgs e)
        {
            switch (cbTipoCaminhao.Text)
            {
                case "Truck":
                    for (int i = 0; i <= 15; i++)
                    {
                        cbQuantidadeAnimais.Items.Add(i.ToString());
                    }

                    break;

                case "Carreta Baixa":
                    for (int i = 0; i <= 25; i++)
                    {
                        cbQuantidadeAnimais.Items.Add(i.ToString());
                    }

                    break;

                case "Carreta Alta":
                    for (int i = 0; i <= 35; i++)
                    {
                        cbQuantidadeAnimais.Items.Add(i.ToString());
                    }

                    break;
            }
                
        }
    }
}
