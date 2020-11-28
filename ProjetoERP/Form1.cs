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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //método de pesquisa do custo com base no nome do custo
        string[] pesquisaCusto(string nome)
        {
            string[] valores = new string[4];
            try
            {
                SqlConnection objcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Novo\source\repos\ProjetoERP\ProjetoERP\ERPOrcamento.mdf;Integrated Security=True");
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("SELECT id_custo, nome_custo, tipo_custo, valor_custo FROM Custos WHERE nome_custo = @nome_custo");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@nome_custo", nome);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = objCmd.ExecuteReader();
                dr.Read();

                valores[0] = dr.GetInt32(0).ToString();
                valores[1] = dr.GetString(1);
                valores[2] = dr.GetString(2);
                valores[3] = dr.GetInt32(3).ToString();
                objcon.Close();

                return valores;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao buscar registro " + erro);
                return valores;
            }

        }

        //método de pesquisa de clientes utilizando o nome
        string[] pesquisaCliente(string nome)
        {
            string[] valores = new string[5];
            try
            {
                SqlConnection objcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Novo\source\repos\ProjetoERP\ProjetoERP\ERPOrcamento.mdf;Integrated Security=True");
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("SELECT IdCliente, NomeCliente, EmailCliente, TelefoneCliente, CelularCliente FROM Clientes WHERE NomeCliente = @NomeCliente");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@NomeCliente", nome);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = objCmd.ExecuteReader();
                dr.Read();

                valores[0] = dr.GetInt32(0).ToString();
                valores[1] = dr.GetString(1);
                valores[2] = dr.GetString(2);
                valores[3] = dr.GetString(3);
                valores[4] = dr.GetString(4);
                objcon.Close();

                return valores;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao buscar registro " + erro);
                return valores;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string nome = comboBox1.Text;
            string[] valores = new string[4];
            valores = pesquisaCusto(nome);
            
            label6.Text = valores[0];
            label7.Text = valores[1];
            label8.Text = valores[2];
            label9.Text = valores[3];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = comboBox2.Text;
            string[] valores = new string[5];
            valores = pesquisaCliente(nome);
            label1.Text = valores[0];
            label2.Text = valores[1];
            label3.Text = valores[2];
            label4.Text = valores[3];
            label5.Text = valores[4];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'eRPOrcamentoDataSet.Custos'. Você pode movê-la ou removê-la conforme necessário.
            this.custosTableAdapter.Fill(this.eRPOrcamentoDataSet.Custos);
            // TODO: esta linha de código carrega dados na tabela 'eRPOrcamentoDataSet.Clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.eRPOrcamentoDataSet.Clientes);

        }
    }
}
