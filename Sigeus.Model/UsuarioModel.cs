namespace Sigeus.Model
{
    public class UsuarioModel // apenas propriedades do usuario e deve comunicar com ( Regra de Negocio/ Front/Acesso a dados)
    {
        public int IdUsuario { get; set; }        
        public string Usuario { get; set; }
        public string Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public int TipoAcesso { get; set; }
        public string ConnectionString { get; } = "Server = LAPTOP-G9AFB89B\\TEW_SQLEXPRESS;Database=Autenticacao_BD;Trusted_Connection=True";
    }
}
