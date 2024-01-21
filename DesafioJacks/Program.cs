// See https://aka.ms/new-console-template for more information

using RegraNegocio;
using AcessoDados;
using Segeus.Interface;
using System.Text;

var tela = new Tela();
tela.MenuInicial();
var comando = tela.LerComandoUsuario();

var regraNegocio = new UsuarioRegraNegocio();


while (comando != "9")
{

    switch (comando)
    {

        case "1":
            tela.LimparTela();
            var cabecalho = new StringBuilder();
            cabecalho.Append("Código | Nome | Perfil | Data Cadastro | Tipo Acesso");
            Console.WriteLine(cabecalho.ToString());
            
            var usuarios = regraNegocio.ListarUsuarios();
            
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"{usuario.IdUsuario}|{usuario.Usuario}|{usuario.Perfil}|{usuario.DataCadastro}|{usuario.TipoAcesso}");
            }

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            tela.MenuInicial();
            comando = tela.LerComandoUsuario();

            break;

        case "2":
           
            break;

        case "9":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida. Pressione uma tecla para continuar...");
            Console.ReadKey();
            tela.MenuInicial();
            break;



    }
}
