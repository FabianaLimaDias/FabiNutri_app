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
        private UsuarioAcessoDados UsuarioAcessoDados { get; set; } 
        public UsuarioRegraNegocio()
        {
            this.UsuarioAcessoDados  = new UsuarioAcessoDados();
        }
        public List<UsuarioModel> ListarUsuarios()
        {           
            return this.UsuarioAcessoDados.ListarUsuarios();
        }

        public UsuarioModel BuscarUsuario(int idUsuario)
        {
            return this.UsuarioAcessoDados.BuscarUsuario(idUsuario);
        }

        public UsuarioModel ExcluirUsuario(int idUsuario)
        {
            return UsuarioAcessoDados.ExcluirUsuario(idUsuario);
        }

        public UsuarioModel CadastrarUsuario(UsuarioModel novoUsuario)
        {
            try
            {
                return UsuarioAcessoDados.CadastrarUsuario(novoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioModel EditarCadastro (int idUsuario, string senhaAtual)
        {
            try
            {
                return UsuarioAcessoDados.EditarCadastro(idUsuario, senhaAtual);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
