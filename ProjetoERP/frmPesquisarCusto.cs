using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjetoERP
{
    public partial class frmPesquisarCusto : Form
    {
        public frmPesquisarCusto()
        {
            InitializeComponent();
        }

        private void btnPesquisarNome_Click(object sender, EventArgs e)
        {
            string nome = comboBox2.Text;
            string[] valores = new string[4];
            valores = Operacoes.pesquisaCustoNome(nome);
            textBox1.Text = valores[0];
            txbNome.Text = valores[1];
            txbTipo.Text = valores[2];
            txbValor.Text = valores[3];
            int id = Convert.ToInt32(valores[0]);
            if(id == 10||id==11||id==12||id==18)
            {
                txbNome.ReadOnly = true;
                txbTipo.ReadOnly = true;
                btnExcluir.Enabled = false;
            }
        }

        private void btnPesquisarId_Click(object sender, EventArgs e)
        {
            string id = comboBox3.Text;
            string[] valores = new string[4];
            valores = Operacoes.pesquisaCustoId(id);
            textBox1.Text = valores[0];
            txbNome.Text = valores[1];
            txbTipo.Text = valores[2];
            txbValor.Text = valores[3];
            int id2 = Convert.ToInt32(valores[0]);
            if (id2 == 10 || id2 == 11 || id2 == 12 || id2 == 18)
            {
                txbNome.ReadOnly = true;
                txbTipo.ReadOnly = true;
                btnExcluir.Enabled = false;
            }


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string id, nome, tipo, valor;
            id = textBox1.Text;
            nome = txbNome.Text;
            tipo = txbTipo.Text;
            valor = txbValor.Text;

            if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("O campo nome e tipo devem ser preenchidos");
            }
            else if (nome == "mao de obra" || nome == "gases" || nome == "insumos" || nome == "numero proposta" || tipo == "mao de obra" || tipo == "gases" || tipo == "insumos" || tipo == "numero proposta")
            {
                MessageBox.Show("nome ou tipo invalido para atualização!");
            }
            else
            {
                Operacoes.atualizaCustoId(id, nome, tipo, valor);
                MessageBox.Show("Itens salvos com sucesso!");
                txbNome.ReadOnly = false;
                txbNome.Clear();
                txbTipo.ReadOnly = false;
                txbTipo.Clear();
                btnExcluir.Enabled = true;
                txbNome.Clear();
                textBox1.Clear();
                txbValor.Clear();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            DialogResult resultado = MessageBox.Show("Deseja deletar o cadastro " + id + "?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (resultado.Equals(DialogResult.OK))
            {
                Operacoes.deletaCusto(id);
                textBox1.Text = "";
                txbNome.Text = "";
                txbTipo.Text = "";
                txbValor.Text = "";
            }
            else
            {

            }
        }

        private void frmPesquisarCusto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'eRPOrcamentoDataSet.Custos'. Você pode movê-la ou removê-la conforme necessário.
            this.custosTableAdapter.Fill(this.eRPOrcamentoDataSet.Custos);

        }
    }
}
