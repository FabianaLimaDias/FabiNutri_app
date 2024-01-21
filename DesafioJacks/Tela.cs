using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segeus.Interface /// FRONT .. comunica com o usuario e a Regra de Negocio
{
    public class Tela
    {
        public void MenuInicial()
        {
            LimparTela();

            PrintarLinha();
            Console.WriteLine(" SIGEUS - Sistema de Gestão de Usuarios");
            PrintarLinha();

            Console.WriteLine();
            Console.WriteLine("1 - Listar Usuários");
            Console.WriteLine("2 - Cadastrar Usuários");
            Console.WriteLine("3 - Editar Usuários");
            Console.WriteLine("4 - Consultar Dados de um Usuários");
            Console.WriteLine("5 - Excluir Usuários");
            Console.WriteLine("6 - Listar Perfil ");
            Console.WriteLine("7 - Consultar Perfil");
            Console.WriteLine("8 - Excluir Perfil");
            Console.WriteLine("9 - Sair");
            Console.WriteLine();

            PrintarLinha();          
            
        }

        public string LerComandoUsuario()
        {
            Console.Write(" Informe a opção desejada: ");
            var comandoSelecionado = Console.ReadLine();
            return comandoSelecionado;          
        }

        public void PrintarLinha()
        {
            string linha = new StringBuilder().Insert(0, "=", 40).ToString();
            Console.WriteLine(linha);
        }

        public void LimparTela()
        {
            Console.Clear();
        }
    }
}
