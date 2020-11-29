using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ProjetoERP
{
    class Operacoes
    {
        //String de conexão
        public static string string_conexao = Properties.Settings.Default.String_conexao;
      

        //método de pesquisa de custo utilizando o nome
        public static string[] pesquisaCustoNome(string nome)
        {
            string[] valores = new string[4];
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("SELECT id_custo, nome_custo, tipo_custo, valor_custo FROM Custos WHERE nome_custo = @nome");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@nome", nome);

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


        //método de pesquisa valor de custo utilizando o nome
        public static string pesquisaValorCustoPorNome(string nome)
        {
            string[] valores = new string[4];
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("SELECT id_custo, nome_custo, tipo_custo, valor_custo FROM Custos WHERE nome_custo = @nome");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@nome", nome);

                objCmd.CommandType = CommandType.Text;

                SqlDataReader dr;
                dr = objCmd.ExecuteReader();
                dr.Read();

                valores[0] = dr.GetInt32(0).ToString();
                valores[1] = dr.GetString(1);
                valores[2] = dr.GetString(2);
                valores[3] = dr.GetInt32(3).ToString();
                objcon.Close();

                return valores[3];
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao buscar registro " + erro);
                return "0";
            }
        }



        //método de pesquisa de custo utilizando o id
        public static string[] pesquisaCustoId(string id)
        {
            string[] valores = new string[4];
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("SELECT id_custo, nome_custo, tipo_custo, valor_custo FROM Custos WHERE id_custo = @id");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@id", id);

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
                MessageBox.Show("Erro ao pesquisar registro " + erro);
                return valores;
            }
        }


        //método de atualização de custo
        public static void atualizaCustoId(string id, string nome, string tipo, string valor)
        {
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("UPDATE Custos SET nome_custo = @nome, tipo_custo = @tipo, valor_custo = @valor WHERE id_custo = @id");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@id", id);
                objCmd.Parameters.AddWithValue("@nome", nome);
                objCmd.Parameters.AddWithValue("@tipo", tipo);
                objCmd.Parameters.AddWithValue("@valor", valor);
                objCmd.ExecuteNonQuery();
                objcon.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao atualizar registro " + erro);
            }
        }


        //função de deletar custo
        public static void deletaCusto(string id)
        {
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("DELETE FROM Custos WHERE id_custo = @id");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@id", id);
                objCmd.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Item deletado com sucesso!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Deletar registro " + erro);
            }
        }

        //metodo de insercao de custos na tabela
        public static void insereCusto(string nome, string tipo, string valor)
        {
            string[] valores = new string[4];
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("INSERT INTO Custos (nome_custo, tipo_custo, valor_custo)" +
                    "VALUES (@nome, @tipo, @valor)");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@nome", nome);
                objCmd.Parameters.AddWithValue("@tipo", tipo);
                objCmd.Parameters.AddWithValue("@valor", valor);
                objCmd.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Itens inseridos com sucesso!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao inserir registro " + erro);
            }
        }


        //método de pesquisa de clientes utilizando o nome
        public static string[] pesquisaClienteNome(string nome)
        {
            string[] valores = new string[5];
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
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


        //método de pesquisa de clientes utilizando o id
        public static string[] pesquisaClienteId(string id)
        {
            string[] valores = new string[5];
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("SELECT IdCliente, NomeCliente, EmailCliente, TelefoneCliente, CelularCliente FROM Clientes WHERE IdCliente = @IdCliente");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@IdCliente", id);

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
                MessageBox.Show("Erro ao pesquisar registro " + erro);
                return valores;
            }
        }


        //método de atualização de clientes
        public static void atualizaClienteId(string id, string nome, string email, string telefone, string celular)
        {
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("UPDATE Clientes SET NomeCliente = @nome, EmailCliente = @email, TelefoneCliente = @telefone, CelularCliente = @celular WHERE IdCliente = @id");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@id", id);
                objCmd.Parameters.AddWithValue("@nome", nome);
                objCmd.Parameters.AddWithValue("@email", email);
                objCmd.Parameters.AddWithValue("@telefone", telefone);
                objCmd.Parameters.AddWithValue("@celular", celular);
                objCmd.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Itens salvos com sucesso!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao atualizar registro " + erro);
            }
        }


        //função de deletar cliente
        public static void deletaCliente(string id)
        {
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("DELETE FROM Clientes WHERE IdCliente = @id");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@id", id);
                objCmd.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Item deletado com sucesso!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Deletar registro " + erro);
            }
        }

        //função de inserção de clientes
        public static void insereCliente(string nome, string email, string telefone, string celular)
        {
            string[] valores = new string[5];
            try
            {
                SqlConnection objcon = new SqlConnection(string_conexao);
                objcon.Open();


                SqlCommand objCmd = new SqlCommand("INSERT INTO Clientes (NomeCliente, EmailCliente, TelefoneCliente, CelularCliente)" +
                    "VALUES (@nome, @email, @telefone, @celular)");
                objCmd.Connection = objcon;
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@nome", nome);
                objCmd.Parameters.AddWithValue("@email", email);
                objCmd.Parameters.AddWithValue("@telefone", telefone);
                objCmd.Parameters.AddWithValue("@celular", celular);
                objCmd.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("Itens inseridos com sucesso!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao adicionar registro " + erro);
            }
        }




    }
}