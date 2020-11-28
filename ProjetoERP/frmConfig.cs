using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoERP
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.Description = "Selecione a pasta onde os arquivos serão salvos";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBox1.Text = fbd.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                }
            }
            textBox2.Text = filePath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string modelo = textBox2.Text;
            string caminho = textBox1.Text;
            Properties.Settings.Default.arquivoModelo = modelo;
            Properties.Settings.Default.caminhoExcel = caminho;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.caminhoExcel;
            textBox2.Text = Properties.Settings.Default.arquivoModelo;
            
        }
    }
}
