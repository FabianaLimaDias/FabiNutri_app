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
        #region [+] Variáveis Privadas


        private string mensagem;
        private BancoSqlServer bancoSqlServer;

        #endregion

        #region [+] Construtor

        public UsuarioAcessoDados()
        {
            this.bancoSqlServer = new BancoSqlServer();
        }

        #endregion

        #region [+] Método Listar Usuario

        public List<UsuarioModel> ListarUsuarios()
        {
            var listaUsuarios = new List<UsuarioModel>();

            try
            {
                var consultaSQL = "SELECT * FROM usuario_tb";
                DataTable dadosTabela = bancoSqlServer.ConsultarBancoDeDados(consultaSQL);

                foreach (DataRow row in dadosTabela.Rows)//data row representa uma unica linha de dados
                {
                    var usuario = new UsuarioModel
                    {
                        IdUsuario = Convert.ToInt32(row["idUsuario"]),
                        Usuario = row["usuario"].ToString().ToUpper(),
                        //Perfil = row["perfil"].ToString().ToUpper(),
                        DataCadastro = Convert.ToDateTime(row["dataCadastro"]),
                        IdTipoAcesso = Convert.ToInt32(row["idTipoAcesso"]),

                    };

                    listaUsuarios.Add(usuario);

                }
            }
            catch (Exception ex)
            {

                mensagem = "Erro ao executar comando no banco de dados: " + ex.Message;
            }

            return listaUsuarios;
        }

        #endregion

        #region  [+] Método Buscar Usuario 
        public UsuarioModel BuscarUsuario(int idUsuario)
        {
            UsuarioModel usuarioRetorno = null;

            try
            {
                var comandoBusca = $"SELECT * FROM usuario_tb WHERE idUsuario = {idUsuario}";
                DataTable dadosUsuario = bancoSqlServer.ConsultarBancoDeDados(comandoBusca);

                //mas pode ser que dadosTabela volte vazio, caso digite um id q nao tem na base
                //testar se a variavel dadosTabela tem linhas

                if (dadosUsuario.Rows.Count > 0) //se for maior que zero significa que recebeu dados
                {
                    usuarioRetorno = new UsuarioModel()
                    {

                        IdUsuario = Convert.ToInt32(dadosUsuario.Rows[0]["idUsuario"]),
                        Usuario = dadosUsuario.Rows[0]["usuario"].ToString().ToUpper(),
                       // Perfil = Convert.ToString(dadosUsuario.Rows[0]["perfil"]),
                        DataCadastro = Convert.ToDateTime(dadosUsuario.Rows[0]["dataCadastro"]),
                        IdTipoAcesso = Convert.ToInt32(dadosUsuario.Rows[0]["idTipoAcesso"])
                    };

                }
                else
                {

                    mensagem = " Id Usuario não existe no Banco de Dados";
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao buscar o Usuario: " + ex.Message;

            }

            return usuarioRetorno;
        }



        #endregion

        #region  [+] Método Editar Cadastro
        public UsuarioModel EditarCadastro(int idUsuario, string senhaAtual)
        {
            

            try
            {
                UsuarioModel usuarioRetorno = null;
                

                var comandoBusca = $"SELECT * FROM usuario_tb WHERE idUsuario = {idUsuario}";
                DataTable dadosUsuario = bancoSqlServer.ConsultarBancoDeDados(comandoBusca);

                //mas pode ser que dadosTabela volte vazio, caso digite um id q nao tem na base
                //testar se a variavel dadosTabela tem linhas

                if (dadosUsuario.Rows.Count > 0) //se for maior que zero significa que recebeu dados
                {
                    var comandoUpdate = $"UPDATE usuario_tb SET senhaAtual = '{senhaAtual}' WHERE idUsuario ='{idUsuario}'";
                    bancoSqlServer.ExecutarComandoBancoDeDados(comandoUpdate);

                    usuarioRetorno = new UsuarioModel()
                    {
                        IdUsuario = Convert.ToInt32(dadosUsuario.Rows[0]["IdUsuario"]),
                        Usuario = Convert.ToString(dadosUsuario.Rows[0]["Usuario"]),
                        NomeUsuario = Convert.ToString(dadosUsuario.Rows[0]["NomeUsuario"]),
                        SenhaAtual = senhaAtual,
                    };

                }
                else
                {
                    mensagem = " Id Usuario não existe no Banco de Dados";
                }

                return usuarioRetorno;

            }
            catch (Exception ex)
            {
                mensagem = "Erro ao buscar o Usuario: " + ex.Message;
                return null;
            }
        }
        #endregion

        #region  [+] Método Excluir Usuario
        public UsuarioModel ExcluirUsuario(int idUsuario)
        {
            UsuarioModel usuarioRetorno = null;

            //verifica se o usuario existe antes de excluir
            var comandoConsulta = $"SELECT* FROM usuario_tb WHERE idUsuario = {idUsuario}";
            DataTable dadosUsuario = bancoSqlServer.ConsultarBancoDeDados(comandoConsulta);


            if (dadosUsuario.Rows.Count > 0)
            {
                //se o usuario existe ,exclua
                comandoConsulta = $"DELETE FROM usuario_tb WHERE idUsuario = {idUsuario}";
                bancoSqlServer.ExecutarComandoBancoDeDados(comandoConsulta);
                //Preencha o objeto usuarioRetorno com os dados do usuario excluído, se necessário
                usuarioRetorno = new UsuarioModel();

            }
            else
            {
                mensagem = " Não é possivel realizar exclusão do usuario. Id não localizado.";
            }

            return usuarioRetorno;//retornar usuario excluido

        }
        #endregion

        #region  [+] Método Cadastrar Usuario
        public UsuarioModel CadastrarUsuario(UsuarioModel novoUsuario)
        {
            try
            {
                UsuarioModel usuarioRetorno = null;

                var comandoInsert = $"INSERT INTO usuario_tb (idEmpresa, idTipoAcesso, usuario, " +
                    $"nomeUsuario, emailUsuario,idPerfil,tipoUsuario,senhaAtual,statusUsuario,dataUltimoAcesso,dataAlteracaoSenha,dataCadastro)" +
                    $"VALUES ({novoUsuario.IdEmpresa}," +
                    $"{novoUsuario.IdTipoAcesso}, " +
                    $"'{novoUsuario.Usuario}', " +
                    $"'{novoUsuario.NomeUsuario}'," +
                    $"'{novoUsuario.EmailUsuario}'," +
                    $"'{novoUsuario.Perfil}', " +
                    $"'{novoUsuario.TipoUsuario}'," +
                    $"'{novoUsuario.SenhaAtual}'," +
                    $"'{novoUsuario.StatusUsuario}'," +
                    $"'{novoUsuario.DataUltimoAcesso.ToString("yyyy-MM-dd HH:mm:ss.FFFFFFF")}'," +
                    $"'{novoUsuario.DataAlteracaoSenha.ToString("yyyy-MM-dd HH:mm:ss.FFFFFFF")}'," +
                    $"'{novoUsuario.DataCadastro.ToString("yyyy-MM-dd HH:mm:ss")}')";

                bancoSqlServer.ExecutarComandoBancoDeDados(comandoInsert);

                var comandoConsulta = $"SELECT * FROM usuario_tb WHERE emailUsuario = '{novoUsuario.EmailUsuario}'";
                var dtUsuario = bancoSqlServer.ConsultarBancoDeDados(comandoConsulta);

                return usuarioRetorno = novoUsuario;
                {
                    //esse nao precisa//
                    novoUsuario.IdUsuario = Convert.ToInt32(dtUsuario.Rows[0]["IdUsuario"]);
                    novoUsuario.Usuario = Convert.ToString(dtUsuario.Rows[0]["Usuario"]);
                    novoUsuario.NomeUsuario = Convert.ToString(dtUsuario.Rows[0]["NomeUsuario"]);
                    novoUsuario.DataCadastro = Convert.ToDateTime(dtUsuario.Rows[0]["DataCadastro"]);
                    novoUsuario.EmailUsuario = Convert.ToString(dtUsuario.Rows[0]["EmailUsuario"]);
                };


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        #endregion
    }
}




