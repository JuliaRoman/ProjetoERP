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
    public partial class frmAdicionarCliente : Form
    {
        public frmAdicionarCliente()
        {
            InitializeComponent();
        }
        //evento do botão adicionar
        private void button1_Click(object sender, EventArgs e)
        {
            string nome, email, telefone, celular;
            nome = textBox2.Text;
            email = textBox3.Text;
            telefone = maskedTextBox1.Text;
            celular = maskedTextBox2.Text;

            //validação para o campo nome, que nao pode ser vazio
            if (String.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Ao menos o campo 'nome' deve ser inserido!");
            }
            else
            {
                //inserção de clientes e, apos isso, os campos sao limpos
                Operacoes.insereCliente(nome, email, telefone, celular);
                textBox2.Clear();
                textBox3.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
            }
        }

        //leva o cursor para o inicio ao clicar na tmasked text box
        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Select(0, 0);
        }

        private void maskedTextBox2_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Select(0, 0);
        }
    }
}
