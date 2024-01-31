using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Sigeus.DataSet
{
    public class BancoSqlServer
    {

        public string ConnectionString;//aonde fica salva o usuario e senha banco 
        public SqlConnection ConexaoBancoDeDados;//criada para abrir e fechar conexao banco

        public BancoSqlServer()
        {

            //fixa string de conexao
            //passa conexao instanciando na propriedade criada

            try
            {
                ConnectionString = "Server = LAPTOP-G9AFB89B\\TEW_SQLEXPRESS;Database=Autenticacao_BD;User ID=sa;Password=#Arthur15;Encrypt=False";
                ConexaoBancoDeDados = new SqlConnection(ConnectionString);
            }

            catch (Exception ex)
            {
                throw new Exception(" Erro ao inicializar a conexão" + ex.Message);
            }
        }

       private void IniciarConexaoBanco()
        {//Abre a conexão com o Banco de Dados , senão estiver aberto !=( diferente de igual)
            try
            {
                if (ConexaoBancoDeDados.State != ConnectionState.Open)
                {
                    ConexaoBancoDeDados.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao abrir a conexão" + ex.Message);
            }
        }

        private void EncerrarConexaoBanco()
        {//fecha se estiver aberto
            if (ConexaoBancoDeDados.State != ConnectionState.Closed)
            {
                ConexaoBancoDeDados.Close();
            }
        }
        //Criado um metodo de Consulta

        public DataTable ConsultarBancoDeDados (string sql) 
        {
            DataTable dadosTabela = new DataTable();//DataTable estrutura tabular em memoria que pdoe armazenar daods em linhas e colunas, semelhantes a uma tabela de banco de dados

            try// inicia um bloco, executado quando envolve um codigo que pode lançar execão, se ocorrer dentro do bloco e sera tranferido para catch
            {
                this.IniciarConexaoBanco();
                var comando = new SqlCommand(sql, ConexaoBancoDeDados);//criada variavel comando responsavel por executar as consultas e instanciamos SlqCommando e passamos o parametro SQL e conexaobanco 
                comando.CommandTimeout = 0;//define o tempo de conexao como 0, ou seja, nao ha limite de tempo
                var retornaDados = comando.ExecuteReader();//criada variavel para retornar os dados da consulta feita pelo comando realizado
                dadosTabela.Load(retornaDados);//guardar na tabela retonada os dados
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);//excecao
            }
            finally
            {
                this.EncerrarConexaoBanco();//encerrar conexao banco de dados
            }
            return dadosTabela;//retornar os dados da tabela consultada
        }

        public string ExecutarComandoBancoDeDados (string SQL)
        {
            //Comando que não retorna dados, usamos o SQLComando,
            // funciona também para Update/Delete e Insert


            try
            {
                IniciarConexaoBanco();
                var comando = new SqlCommand(SQL, ConexaoBancoDeDados);
                comando.CommandTimeout = 0;
                comando.ExecuteNonQuery();//chama a variavel criada para executar comando que não tras linhas e nem colunas
                return "";//retorno sera vazio
            }

            catch (Exception ex ) 
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                EncerrarConexaoBanco();//encerra conexao 
            }
        }

    }


}