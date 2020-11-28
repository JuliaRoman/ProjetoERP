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
    public partial class frmPesquisarCliente : Form
    {
        public frmPesquisarCliente()
        {
            InitializeComponent();
        }

        private void frmPesquisarCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'eRPOrcamentoDataSet.Clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.eRPOrcamentoDataSet.Clientes);

        }

        private void btnPesquisarNome_Click(object sender, EventArgs e)
        {
            //pesquisa o cliente de acordo com o nome da textbox e insere os dados nos campos
            string nome = comboBox2.Text;
            string[] valores = new string[5];
            valores = Operacoes.pesquisaClienteNome(nome);
            textBox1.Text = valores[0];
            textBox2.Text = valores[1];
            textBox3.Text = valores[2];
            maskedTextBox1.Text = valores[3];
            maskedTextBox2.Text = valores[4];

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //salva os dados no cadastro pesquisado
            string id, nome, email, telefone, celular;
            id = textBox1.Text;
            nome = textBox2.Text;
            email = textBox3.Text;
            telefone = maskedTextBox1.Text;
            celular = maskedTextBox2.Text;
            //if para impedir que seja salvo um cadastro sem nome
            if (String.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Ao menos o campo 'nome' deve ser inserido!");
            }
            else
            {
                Operacoes.atualizaClienteId(id, nome, email, telefone, celular);
                MessageBox.Show("Cadastro atualizado.");
            }
            

        }

        private void btnPesquisarId_Click(object sender, EventArgs e)
        {
            //pesquisa o cliente de acordo com o id da textbox e insere os dados nos campo
            string id = comboBox3.Text;
            string[] valores = new string[5];
            valores = Operacoes.pesquisaClienteId(id);
            textBox1.Text = valores[0];
            textBox2.Text = valores[1];
            textBox3.Text = valores[2];
            maskedTextBox1.Text = valores[3];
            maskedTextBox2.Text = valores[4];
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            //abre caixa de dialogo para confirmar a operação
            DialogResult resultado = MessageBox.Show("Deseja deletar o cadastro " + id + "?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (resultado.Equals(DialogResult.OK))
            {
                //deleta o cadastro pesquisado
                Operacoes.deletaCliente(id);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
            }
            else
            {

            }
        }
    }
}
