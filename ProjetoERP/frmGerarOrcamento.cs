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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Configuration;
using System.Collections.Specialized;


namespace ProjetoERP
{
    public partial class frmGerarOrcamento : Form
    {
        public frmGerarOrcamento()
        {
            InitializeComponent();
        }


        //caminhos dos arquivos
        string pastaSalvar = Properties.Settings.Default.caminhoExcel;
        string caminhoExcel = Properties.Settings.Default.arquivoModelo;

        private void btnGerarOrcamento_Click(object sender, EventArgs e)
        {
            //valores presentes no formulario
            string nomeCliente;
            string emailCliente;
            string celCliente;
            string telCliente;
            //condicional para identificar se foi feita uma inserção manual dos dados
            //se a groupbox estiver visivel, foi feita uma insercao manual, do contrario, foi automatico
            if (groupBoxManual.Visible)
            {
                nomeCliente = txbNomeClienteManual.Text;
                emailCliente = txbEmailClienteManual.Text;
                celCliente = mtbCelClienteManual.Text;
                telCliente = mtbTelClienteManual.Text;
            }
            else
            {
                nomeCliente = comboBoxClientesBanco.Text;
                emailCliente = txbEmailClienteBanco.Text;
                celCliente = mtbCelClienteBanco.Text;
                telCliente = mtbTelClienteBanco.Text;
            }
            //mais valores presentes no formulario
            string nomeContato = txbContato.Text;
            string materialPeca = txbMaterialProduto.Text;
            double diametroPeca = Convert.ToDouble(txbDiametroProduto.Text);
            double comprimentoPeca = Convert.ToDouble(txbComprimentoProduto.Text);
            int qtdPeca = Convert.ToInt16(txbQuantidadeProduto.Text);
            string descricaoPeca = txbDescriçãoProduto.Text;
            string problemaPeca = txbProblemaProduto.Text;
            string tratamentoAtualPeca = txbTratamentoProduto.Text;
            string processoRevest = comboBoxProcessoRevestimento.Text;
            double diametroRevest = Convert.ToDouble(txbDiametroRevestimento.Text);
            double comprimentoRevest = Convert.ToDouble(txbComprimentoRevestimento.Text);
            double espessuraRevest = Convert.ToDouble(txbEspessuraRevestimento.Text);
            string materialRevest = comboBoxMaterialRevestimento.Text;
            double varMateriaPrima = Convert.ToDouble(txbVariacaoMateriaPrima.Text);
            double varInsumos = Convert.ToDouble(txbVariacaoInsumos.Text);
            double varGases = Convert.ToDouble(txbVariacaoGases.Text);
            double varMaoDeObra = Convert.ToDouble(txbVariacaoMaoDeObra.Text);
            bool preparacao = checkBoxPreparacao.Checked;
            bool acabamento = checkBoxAcabamento.Checked; ;
            string tipoPreparacao = comboBoxTipoPreparacao.Text;
            string tipoAcabamento = comboBoxTipoAcabamento.Text;
            double horasPreparacao = Convert.ToDouble(txbHorasPreparacao.Text);
            double varPreparacao = Convert.ToDouble(txbVariacaoPreparacao.Text);
            double horasAcabamento = Convert.ToDouble(txbHorasAcabamento.Text);
            double varAcabamento = Convert.ToDouble(txbVariacaoAcabamento.Text);
            string prazoEntrega = txbPrazoDeEntrega.Text;
            string condPagamento = txbCondicaoPagamento.Text;
            string transporte = comboBoxTransporte.Text;
            double varFinal = Convert.ToDouble(txbVariacaoFinal.Text);



            //valores fixos para calculo
            double fatorBase = 0.01;
            double fator = 0.13;
            int fatorInsumo = 1;
            int fatorHora = 3;
            double valorMaterial = Convert.ToDouble(Operacoes.pesquisaValorCustoPorNome(materialRevest));
            double valorInsumo = Convert.ToDouble(Operacoes.pesquisaValorCustoPorNome("insumo"));
            double valorGases = Convert.ToDouble(Operacoes.pesquisaValorCustoPorNome("gases"));
            double valorMaoDeObra = Convert.ToDouble(Operacoes.pesquisaValorCustoPorNome("mao de obra"));


            //cálculo de valores do orçamento
            double superficieTrabalhoDecimetro = diametroRevest * comprimentoRevest;
            double qtdRevestimento = 0;
            qtdRevestimento = superficieTrabalhoDecimetro * espessuraRevest * fator;
            double custoMaterial = qtdRevestimento * valorMaterial * varMateriaPrima;//custo dos materiais
            double qtdRevestimento2 = Math.Ceiling(200 * superficieTrabalhoDecimetro * fatorBase) / 200;
            double custoInsumo = qtdRevestimento2 * valorInsumo * varInsumos;//custo dos insumos
            double materialPrevisto = (fatorInsumo * qtdRevestimento2) + qtdRevestimento;
            double custoGases = materialPrevisto * valorGases * varGases;//custo dos gases
            double horaTrabalho = Math.Ceiling(qtdRevestimento / fatorHora);
            double custoMaoDeObra = horaTrabalho * valorMaoDeObra * varMaoDeObra;//custo mao de obra
            double somaCustos = custoMaterial + custoInsumo + custoGases + custoMaoDeObra;//valor pré acrescimo
            double valorFinal = varFinal * somaCustos;//valor final
            double valorPorDecimetro = valorFinal / superficieTrabalhoDecimetro;
            double valorQtdFinal = valorFinal * qtdPeca;//contabilizando qtd de peças
            string numProposta = geraNumProposta();//ordem

            //abrindo o arquivo excel base para a edição
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel.Worksheet xlWorksheet;
            xlApp = new Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(caminhoExcel);
            xlWorksheet = xlWorkbook.Worksheets["ref"];

            //inserindo valores
            xlWorksheet.Cells[2, 3] = nomeCliente;
            xlWorksheet.Cells[2, 4] = nomeContato;
            xlWorksheet.Cells[2, 5] = emailCliente;
            xlWorksheet.Cells[2, 6] = celCliente;
            xlWorksheet.Cells[2, 7] = telCliente;
            xlWorksheet.Cells[2, 8] = descricaoPeca;
            xlWorksheet.Cells[2, 9] = qtdPeca;
            xlWorksheet.Cells[2, 10] = diametroRevest;
            xlWorksheet.Cells[2, 11] = comprimentoRevest;
            xlWorksheet.Cells[2, 12] = espessuraRevest;
            xlWorksheet.Cells[2, 13] = materialRevest;
            xlWorksheet.Cells[2, 14] = processoRevest;
            if (preparacao)
            {
                xlWorksheet.Cells[2, 18] = true;
                xlWorksheet.Cells[2, 19] = tipoPreparacao;
            }
            else
            {
                xlWorksheet.Cells[2, 18] = false;
            }
            if (acabamento)
            {
                xlWorksheet.Cells[2, 20] = true;
                xlWorksheet.Cells[2, 21] = tipoAcabamento;
            }
            else
            {
                xlWorksheet.Cells[2, 20] = false;
            }
            xlWorksheet.Cells[2, 22] = valorFinal;
            xlWorksheet.Cells[2, 23] = valorQtdFinal;
            xlWorksheet.Cells[2, 24] = condPagamento;
            xlWorksheet.Cells[2, 25] = prazoEntrega;
            xlWorksheet.Cells[2, 26] = transporte;
            xlWorksheet.Cells[2, 27] = numProposta;

            xlWorksheet.Cells[2, 29] = qtdRevestimento;
            xlWorksheet.Cells[2, 30] = qtdRevestimento2;
            xlWorksheet.Cells[2, 31] = materialPrevisto;
            xlWorksheet.Cells[2, 32] = horaTrabalho;
            xlWorksheet.Cells[2, 33] = valorMaterial;
            xlWorksheet.Cells[2, 34] = valorInsumo;
            xlWorksheet.Cells[2, 35] = valorGases;
            xlWorksheet.Cells[2, 36] = valorMaoDeObra;
            xlWorksheet.Cells[2, 37] = varMateriaPrima;
            xlWorksheet.Cells[2, 38] = varInsumos;
            xlWorksheet.Cells[2, 39] = varGases;
            xlWorksheet.Cells[2, 40] = varMaoDeObra;
            xlWorksheet.Cells[2, 41] = custoMaterial;
            xlWorksheet.Cells[2, 42] = custoInsumo;
            xlWorksheet.Cells[2, 43] = custoGases;
            xlWorksheet.Cells[2, 44] = custoMaoDeObra;
            xlWorksheet.Cells[2, 45] = varFinal;
            xlWorksheet.Cells[2, 46] = valorFinal;
            xlWorksheet.Cells[2, 47] = valorPorDecimetro;

            //salvando o arquivo como um novo arquivo, concatenando o diretório com o numero de proposta
            xlWorkbook.SaveAs(pastaSalvar + @"\orc_" + numProposta + ".xlsm");
            xlWorkbook.Close();
            xlApp.Quit();


        }


        //gera um novo numero de proposta
        string geraNumProposta()
        {
            string proposta = "numero proposta tecnica";
            string[] valores = new string[4];
            valores = Operacoes.pesquisaCustoNome(proposta);
            int num = Convert.ToInt32(valores[3]);
            num++;
            valores[3] = num.ToString();
            Operacoes.atualizaCustoId(valores[0], valores[1], valores[2], valores[3]);
            return valores[3];
        }

        //deixa visivel ou invisivel a goupbox de insercao manual de dados
        private void btnDadosManuais_Click(object sender, EventArgs e)
        {
            if (groupBoxManual.Visible)
                groupBoxManual.Visible = false;
            else
                groupBoxManual.Visible = true;
        }

        //comando padrao gerado pelo visual studio
        private void frmGerarOrcamento_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'eRPOrcamentoDataSet.Custos'. Você pode movê-la ou removê-la conforme necessário.
            this.custosTableAdapter.Fill(this.eRPOrcamentoDataSet.Custos);
            // TODO: esta linha de código carrega dados na tabela 'eRPOrcamentoDataSet.Clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.eRPOrcamentoDataSet.Clientes);

        }

        //preenche os dados do cliente com a pesquisa
        private void button3_Click(object sender, EventArgs e)
        {
            string cliente = comboBoxClientesBanco.Text;
            string[] valores = new string[5];
            valores = Operacoes.pesquisaClienteNome(cliente);
            labelIdCliente.Text = valores[0];
            txbEmailClienteBanco.Text = valores[2];
            mtbTelClienteBanco.Text = valores[3];
            mtbCelClienteBanco.Text = valores[4];
        }
        //habilita campos de preparacao
        private void checkBoxPreparacao_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPreparacao.Checked)
            {
                txbHorasPreparacao.Enabled = true;
                txbVariacaoPreparacao.Enabled = true;
                comboBoxTipoPreparacao.Enabled = true;
            }
            else
            {
                txbHorasPreparacao.Enabled = false;
                txbVariacaoPreparacao.Enabled = false;
                comboBoxTipoPreparacao.Enabled = false;

            }
        }
        //habilita campos de preparacao
        private void checkBoxAcabamento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAcabamento.Checked)
            {
                txbHorasAcabamento.Enabled = true;
                txbVariacaoAcabamento.Enabled = true;
                comboBoxTipoAcabamento.Enabled = true;
            }
            else
            {
                txbHorasAcabamento.Enabled = false;
                txbVariacaoAcabamento.Enabled = false;
                comboBoxTipoAcabamento.Enabled = false;

            }
        }

        //comandos que ajustam as masked text box
        private void mtbCelClienteBanco_Click(object sender, EventArgs e)
        {
            mtbCelClienteBanco.Select(0, 0);
        }
        private void mtbTelClienteBanco_Click(object sender, EventArgs e)
        {
            mtbTelClienteBanco.Select(0, 0);
        }
        private void mtbTelClienteManual_Click(object sender, EventArgs e)
        {
            mtbTelClienteManual.Select(0, 0);
        }
        private void mtbCelClienteManual_Click(object sender, EventArgs e)
        {
            mtbCelClienteManual.Select(0, 0);
        }
    }
}
