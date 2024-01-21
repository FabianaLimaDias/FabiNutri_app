using Sigeus.DataSet;
using Sigeus.Model;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;
using System.Data;


namespace AcessoDados
{

    public class UsuarioAcessoDados


    {

        public bool status;
        public string tabela;
        public string mensagem;
        public BancoSqlServer bancoSqlServer;


        public List<UsuarioModel> ListaUsuarios = new List<UsuarioModel>();

        public UsuarioAcessoDados()
        {
            bancoSqlServer = new BancoSqlServer();
        }
       

        public List<UsuarioModel> ListarUsuarios()

        {
            status = true;

            try
            {
                bancoSqlServer.IniciarConexaoBanco();
                ListaUsuarios.Clear();

                var consultaSQL = "Select * from usuario_tb";
                DataTable dadosTabela = bancoSqlServer.ConsultarBancoDeDados(consultaSQL);

                foreach(DataRow row in dadosTabela.Rows)//data row representa uma unica linha de dados
                {
                    UsuarioModel usuario = new UsuarioModel
                    {

                        IdUsuario = Convert.ToInt32(row["idUsuario"]),
                        Usuario = row["usuario"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["dataCadastro"])

                    };

                ListaUsuarios.Add(usuario);

                }

                tabela = "usuario_tb";
                mensagem = "Conexão com a tabela com sucesso";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com a tabela com erro: " + ex.Message;
            }
            finally
            {
                bancoSqlServer.EncerrarConexaoBanco();
            }
           
            return ListaUsuarios;
         }


        public string BuscarUsuarioIdUsuario (int idUsuario)
        {
            status = true;
            try
            {
                bancoSqlServer.IniciarConexaoBanco();
                var comandoBusca = $"SELECT idUsuario FROM usuario_tb WHERE ID {idUsuario}";
                DataTable dadosTabela = bancoSqlServer.ConsultarBancoDeDados(comandoBusca);
              
                //mas pode ser que dadosTabela volte vazio, caso digite um id q nao tem na base
               //testar se a variavel dadosTabela tem linhas

                if(dadosTabela.Rows.Count > 0) //se for maior que zero signidica que recebeu dados
                {
                    string conteudo = dadosTabela.Rows[0].ToString();
                    status = true;
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = " Id Usuario não existe no Banco de Dados";
                }

                        
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao buscar o Usuario: " + ex.Message;

            }
            finally
            {
                bancoSqlServer.EncerrarConexaoBanco();
            }
            return "";
        }
    }
}

        //public void CadastrarUsuario(UsuarioModel novoUsuario)
        //{
        //    //entrada parametro ( usuarioModel novoUsuario -- pensar no id)
        //    status = true;
        //    try
        //    {
        //        // incluir usuario na base
        //        //INSERT INTO USUARIO ..VALUES
        //        var SQL = "INSERT INTO usuario (Nome) VALUES(@Nome)";//comando de inserir
        //        DateTime dateTime = DateTime.Now;
        //        listaUsuarios.Add();
        //        novoUsuario.DataCadastro = DateTime.Now;
        //        ConexaoBancoDeDados.SqlCommand()
        //        if (File.Exists(diretorio ))
        //        {
        //            status = false;
                    
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //    }

        //}
            
    


        //public void CadastrarUsuario() {
        //    UsuarioAcessoDados novoUsuario = new UsuarioAcessoDados();//pq?
        //    Console.WriteLine("Digite Nome do usuario: ");
        //    novoUsuario.nome = Console.ReadLine(); //preencher nome

        //    Usuarios.Add(novoUsuario);//guarda nome na lista
        //    novoUsuario.dataCadastro = DateTime.Now;



        //}

        //public void EditarUsuario()
        //{
        //    Console.WriteLine("Digite o usuario que deseja editar: ");
        //    int codigoEditar = Convert.ToInt32(Console.ReadLine());


        //    foreach (var acessoLista in Usuarios)
        //    {
        //        Console.WriteLine(acessoLista);
        //    }
        //}

        //    public void ConsultaUsuarios()
        //    {

        //        ListaUsuario();
        //    }


        //    public void ExcluirUsuario()
        //    {

        //        Console.WriteLine("Digite nome do Usuario que deseja excluir: ");
        //    string exclusaoUsuario = Convert.ToString(Console.ReadLine());


        //    if (exclusaoUsuario == nome)
        //    {
        //       // exclusaoUsuario.Remove(nome); nao consegui
        //        Console.WriteLine($"Exclusão usuario: {exclusaoUsuario} realizada com sucesso");
        //    }
        //    else
        //        Console.WriteLine("Usuario não localizado em nossos cadastros");
        //}

        
   
    
