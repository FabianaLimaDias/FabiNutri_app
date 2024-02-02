// See https://aka.ms/new-console-template for more informationusing RegraNegocio;using AcessoDados;using Segeus.Interface;using System.Text;using Sigeus.Model;using System.Collections.Generic;using System;var tela = new Tela();tela.MenuInicial();var comando = tela.LerComandoUsuario();var regraNegocio = new UsuarioRegraNegocio();while (comando != "9"){    switch (comando)    {        case "1"://listar usuario            tela.LimparTela();            var cabecalho = new StringBuilder();            cabecalho.Append($" Código  | {tela.AdicionarEspaco("Nome",26)} | Perfil   |  Data Cadastro | Tipo Acesso  ");            Console.WriteLine(cabecalho.ToString());            var listaUsuarios = regraNegocio.ListarUsuarios();            foreach (var user in listaUsuarios)            {                Console.WriteLine($" {user.IdUsuario} |{tela.AdicionarEspaco(user.Usuario, 30 - user.Usuario.Length)} |{user.Perfil}  |  {user.DataCadastro}    |{user.IdTipoAcesso}");            }            Console.WriteLine("Pressione uma tecla para continuar...");            Console.ReadKey();            tela.MenuInicial();            comando = tela.LerComandoUsuario();            break;        case "2"://cadastrar usuario            try            {                tela.LimparTela();                var novoUsuario = new UsuarioModel()                {                    IdEmpresa = 1,//FabiNutri
                    IdTipoAcesso = 3,                    Usuario = "Paulo",                    NomeUsuario = "Paulo Ferreira",                    EmailUsuario = "paulo.f@hotmail.com",                    IdPerfil = 3,                    TipoUsuario = 3,                    SenhaAtual = "#Alterar5",                    StatusUsuario = "A",                    DataUltimoAcesso = DateTime.Now,                    DataAlteracaoSenha = DateTime.Now,
                    DataCadastro = DateTime.Now

                };                                var usuarioCadastrado = regraNegocio.CadastrarUsuario(novoUsuario);                if (usuarioCadastrado != null)                {                    Console.WriteLine($"Cadastro realizado com sucesso | idUsuario: {novoUsuario.IdUsuario} | Nome: {novoUsuario.NomeUsuario}");                }                            }            catch (Exception ex)            {                Console.WriteLine ($"Não foi possível Cadastrar o usuário. Motivo:{ex.Message}");            }            Console.WriteLine("Pressione uma tecla para continuar...");            Console.ReadKey();            tela.MenuInicial();            comando = tela.LerComandoUsuario();            break;


        case "3"://ALTERACAO

            try
            {
                tela.LimparTela();

                Console.WriteLine(" Digite o id do usuário para realizar a alteração: ");
                var idUsuarioEditado = Convert.ToInt32(Console.ReadLine());

                var editarUsuario = new UsuarioModel();
                if (idUsuarioEditado!= null)
                {
                    Console.WriteLine("Digite a nova senha: ");
                    var novaSenha = Console.ReadLine();

                    editarUsuario = regraNegocio.EditarCadastro(idUsuarioEditado, novaSenha);

                    Console.WriteLine($"Alteração realizada com sucesso | ID do Usuário: {editarUsuario.IdUsuario}| Nova Senha: {editarUsuario.SenhaAtual}");

                }
                else
                {
                        Console.WriteLine("Usuário não encontrado.");
                }
                
            }
     
            catch (Exception ex)            {                Console.WriteLine($"Não foi possível Cadastrar o usuário. Motivo:{ex.Message}");            }
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
            tela.MenuInicial();
            comando = tela.LerComandoUsuario();
            break;

        case "4"://Consultar Usuario
            tela.LimparTela();

            Console.WriteLine(" Digite o id do usuário: ");            var idUsuario = Convert.ToInt32(Console.ReadLine());            var usuarioConsultado = regraNegocio.BuscarUsuario(idUsuario);


            if (usuarioConsultado != null)            {                cabecalho = new StringBuilder();                cabecalho.Append("Código | Nome | Perfil | Data Cadastro | Tipo Acesso");                Console.WriteLine(cabecalho.ToString());                Console.WriteLine($"{usuarioConsultado.IdUsuario}|{usuarioConsultado.Usuario}|{usuarioConsultado.Perfil}|{usuarioConsultado.DataCadastro} |{usuarioConsultado.IdTipoAcesso}");

            }            else            {                Console.WriteLine("Usuario não encontrado. ");            }            Console.WriteLine("Pressione uma tecla para continuar...");            Console.ReadKey();            tela.MenuInicial();            comando = tela.LerComandoUsuario();            break;        case "5"://excluir usuario            tela.LimparTela();            Console.WriteLine(" Digite o id do usuário para realizar a exclusão: ");            idUsuario = Convert.ToInt32(Console.ReadLine());            usuarioConsultado = regraNegocio.ExcluirUsuario(idUsuario);            if (usuarioConsultado != null)            {                               Console.WriteLine($"Exclusão realizada com sucesso");            }            else            {                Console.WriteLine("Usuario não encontrado. ");            }            Console.WriteLine("Pressione uma tecla para continuar...");            Console.ReadKey();            tela.MenuInicial();            comando = tela.LerComandoUsuario();            break;        case "9":            Environment.Exit(0);            break;        default:            Console.WriteLine("Opção inválida. Pressione uma tecla para continuar...");            Console.ReadKey();            tela.MenuInicial();            break;    }}