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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmGerarOrcamento frmGerarOrcamento = new frmGerarOrcamento();
            frmGerarOrcamento.ShowDialog();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            //encerra a aplicação
            this.Close();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void pesquisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPesquisarCliente frmPesquisarCliente = new frmPesquisarCliente();
            frmPesquisarCliente.ShowDialog();
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAdicionarCliente frmAdicionarCliente = new frmAdicionarCliente();
            frmAdicionarCliente.ShowDialog();
        }

        private void pesquisaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPesquisarCusto frmPesquisarCusto = new frmPesquisarCusto();
            frmPesquisarCusto.ShowDialog();
        }

        private void cadastroToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAdicionarCusto frmAdicionarCusto = new frmAdicionarCusto();
            frmAdicionarCusto.ShowDialog();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.ShowDialog();
        }
    }
}
