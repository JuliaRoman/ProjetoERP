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
    public partial class frmAdicionarCusto : Form
    {
        public frmAdicionarCusto()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string nome, tipo, valor;
            nome = textBox2.Text;
            tipo = comboBoxTipo.Text;
            valor = textBox1.Text;
            //validação do nome do cadstro
            if (String.IsNullOrEmpty(nome)||String.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("O campo nome e tipo devem ser preenchidos");
            }
            //validação para casos específicos de valores guardados no banco
            else if (nome == "mao de obra" || nome == "gases" || nome == "insumos" || nome == "numero proposta" || tipo == "mao de obra" || tipo == "gases" || tipo == "insumos" || tipo == "numero proposta")
            {
                MessageBox.Show("nome ou tipo invalido para cadastro!");
            }
            else
            {
                Operacoes.insereCusto(nome, tipo, valor);
                textBox2.Clear();
                textBox1.Clear();
            }
        }
    }
}
