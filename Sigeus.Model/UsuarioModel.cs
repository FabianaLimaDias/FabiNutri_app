namespace Sigeus.Model
{
    public class UsuarioModel // apenas propriedades do usuario e deve comunicar com ( Regra de Negocio/ Front/Acesso a dados)
    {
        public int IdUsuario { get; set; }
        public int IdEmpresa { get; set; }

        public int IdTipoAcesso { get; set; }
        public string Usuario { get; set; }

        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string Perfil { get; set; }

        public int TipoUsuario { get; set; }

        public string SenhaAtual {get; set;}
       public string StatusUsuario { get; set;}

        public DateTime DataUltimoAcesso { get; set; }
        public DateTime DataAlteracaoSenha { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public string ConnectionString { get; } = "Server = LAPTOP-G9AFB89B\\TEW_SQLEXPRESS;Database=Autenticacao_BD;Trusted_Connection=True";
    }
}
