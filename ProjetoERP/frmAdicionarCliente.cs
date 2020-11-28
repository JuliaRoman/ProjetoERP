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

        private void button1_Click(object sender, EventArgs e)
        {
            string nome, email, telefone, celular;
            nome = textBox2.Text;
            email = textBox3.Text;
            telefone = maskedTextBox1.Text;
            celular = maskedTextBox2.Text;

            if (String.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Ao menos o campo 'nome' deve ser inserido!");
            }
            else
            {
                Operacoes.insereCliente(nome, email, telefone, celular);
                textBox2.Clear();
                textBox3.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
            }
        }

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
