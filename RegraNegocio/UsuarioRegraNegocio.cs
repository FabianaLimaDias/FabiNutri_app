using AcessoDados;
using Sigeus.DataSet;
using Sigeus.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegraNegocio
{
    public class UsuarioRegraNegocio /// Regra de Negocio - comunica com Front e Acesso de Dados
    {
        private BancoSqlServer bancoSqlServer;

        public UsuarioRegraNegocio()
        {
            bancoSqlServer =  new BancoSqlServer();

        }
        public List<UsuarioModel> ListarUsuarios()
        {
           
            List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
            
           
                var consultaSQL = "Select * from usuario_tb";
                DataTable dadosTabela = bancoSqlServer.ConsultarBancoDeDados(consultaSQL);

                foreach (DataRow row in dadosTabela.Rows)
                {
                    UsuarioModel usuario = new UsuarioModel
                    {
                       

                        IdUsuario = Convert.ToInt32(row["idUsuario"]),
                        Usuario = row["usuario"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["dataCadastro"])
                    };

                    listaUsuarios.Add(usuario);
                   
                  }
                

            return listaUsuarios;

        }

      //  public 
    }
}
