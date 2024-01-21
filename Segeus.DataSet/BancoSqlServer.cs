using System;
using System.Data.SqlClient;

namespace Sigeus.DataSet
{
    public class BancoSqlServer
    {

        public string stringDeConexao { get; } = "Server = LAPTOP-G9AFB89B\\TEW_SQLEXPRESS;Database=Autenticacao_BD;Trusted_Connection=True";//mudar

        public void ConectarBancoDeDados()
        {
            
            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                conexao.Open();

                //using (SqlCommand comando = new SqlCommand()) 
                //{
                //    comando.Connection = conexao;// 11 a 20
                //    comando.CommandText = "SELECT * FROM usuario_tb";

                //    SqlDataReader leitorDeDados = comando.ExecuteReader();//sqldatareader arcaico -- executeReader ir no banco e fazer leitura

                //    while (leitorDeDados.Read())
                //    {
                //      int CodigoUsuario = (Int32)leitorDeDados["idUsuario"];
                //       Console.WriteLine(CodigoUsuario.ToString());

                //        string nome = (string)leitorDeDados["usuario"];
                //        Console.WriteLine(nome);


                //    }

                //    leitorDeDados.Close();
                //}
            }

            //Console.ReadKey();
        }
    }
}