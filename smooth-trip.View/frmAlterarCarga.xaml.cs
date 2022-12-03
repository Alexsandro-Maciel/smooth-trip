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
    public partial class frmAlterarCarga : Window
    {
        Carga carga1 = null;

        public frmAlterarCarga(Carga carga)
        {
            InitializeComponent();

            carga1 = carga;

            Configurar();
        }

        private void Configurar()
        {
            List<string> fazendeiros = new List<string>();
            fazendeiros = cUsuario.ObterNomesFazendeiros();

            List<string> motoristas = new List<string>();
            motoristas = cUsuario.ObterNomesMotoristas();

            foreach (string nome in fazendeiros)
            {
                cbFazendeiroDestinatario.Items.Add(nome);
                cbFazendeiroRemetente.Items.Add(nome);
            }

            foreach (string nome in motoristas)
            {
                cbMotoristaResponsavel.Items.Add(nome);
            }

            cbTipoCaminhao.Items.Add("Truck");
            cbTipoCaminhao.Items.Add("Carreta Baixa");
            cbTipoCaminhao.Items.Add("Carreta Alta");

            cbTipoCaminhao.Text = carga1.Tipo_Caminhao;
            cbQuantidadeAnimais.Text = carga1.Quantidade_Animais.ToString();
            cbMotoristaResponsavel.Text = cUsuario.ObterNomeUsuarioPeloId(carga1.Id_Motorista);
            cbFazendeiroRemetente.Text = cUsuario.ObterNomeUsuarioPeloId(carga1.Id_Fazendeiro_Remetente);
            cbFazendeiroDestinatario.Text = cUsuario.ObterNomeUsuarioPeloId(carga1.Id_Fazendeiro_Destinatario);
            boxDataEntrega.Text = carga1.Data_Entrega;
            boxEnderecoDestino.Text = carga1.Endereco_Destino;
            boxEnderecoOrigem.Text = carga1.Endereco_Origem;
        }

        private void Atualizar(object sender, MouseButtonEventArgs e)
        {
            if (VerificarCampos() == true)
            {
                //Carga carga = new Carga();

                carga1.Id_Fazendeiro_Destinatario = cUsuario.ObterIdUsuario(cbFazendeiroDestinatario.SelectedItem.ToString());
                carga1.Id_Fazendeiro_Remetente = cUsuario.ObterIdUsuario(cbFazendeiroRemetente.SelectedItem.ToString());
                carga1.Id_Motorista = cUsuario.ObterIdUsuario(cbMotoristaResponsavel.SelectedItem.ToString());
                carga1.Endereco_Destino = boxEnderecoDestino.Text;
                carga1.Endereco_Origem = boxEnderecoOrigem.Text;
                carga1.Tipo_Caminhao = cbTipoCaminhao.Text;
                carga1.Quantidade_Animais = Int32.Parse(cbQuantidadeAnimais.SelectedItem.ToString());
                carga1.Data_Entrega = boxDataEntrega.Text;
                carga1.Data_Saida = DateTime.Now.ToString("yyyy-MM-dd");

                if (cCarga.AtualizarCarga(carga1) == true)
                {
                    Close();
                    IrParaFrmMensagemInformacao("Carga atualizada com sucesso!");
                }

                else
                {
                    IrParaFrmMensagemErro("Não foi possível atualizar!");
                }
            }

            else
            {
                IrParaFrmMensagemAvisoOK("Preencha todos os campos!");
            }
        }

        private bool VerificarCampos()
        {
            return cbFazendeiroDestinatario.Text != "" && cbFazendeiroRemetente.Text != ""
                   && boxEnderecoDestino.Text != "" && boxEnderecoOrigem.Text != ""
                   && cbMotoristaResponsavel.Text != "" && cbQuantidadeAnimais.Text != ""
                   && cbTipoCaminhao.Text != "" && boxDataEntrega.Text != "" ? true : false;
        }

        private void VoltarParaFrmInicial(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void EscolheuCaminhao(object sender, SelectionChangedEventArgs e)
        {
            cbQuantidadeAnimais.Items.Clear();
            switch (cbTipoCaminhao.SelectedItem.ToString())
            {
                case "Truck":
                    for (int i = 1; i <= 15; i++)
                    {
                        cbQuantidadeAnimais.Items.Add(i.ToString());
                    }

                    break;

                case "Carreta Baixa":
                    for (int i = 1; i <= 25; i++)
                    {
                        cbQuantidadeAnimais.Items.Add(i.ToString());
                    }

                    break;

                case "Carreta Alta":
                    for (int i = 1; i <= 35; i++)
                    {
                        cbQuantidadeAnimais.Items.Add(i.ToString());
                    }

                    break;
            }
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

    }
}
