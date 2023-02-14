using ProjetoAula04.Controllers;

namespace ProjetoAula04
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("\n *** CONTROLE DE PLANOS E CLIENTES *** \n");
            Console.WriteLine("(1) CADASTRAR PLANO");
            Console.WriteLine("(2) ATUALIZAR PLANO");
            Console.WriteLine("(3) EXCLUIR PLANO");
            Console.WriteLine("(4) CONSULTAR PLANOS");
            Console.WriteLine("(5) CADASTRAR CLIENTE");
            Console.WriteLine("(6) ATUALIZAR CLIENTE");
            Console.WriteLine("(7) EXCLUIR CLIENTE");
            Console.WriteLine("(8) CONSULTAR CLIENTES");
            Console.WriteLine("(0) SAIR DO PROGRAMA");


            Console.Write("\nENTRE COM A OPÇÃO DESEJADA...: ");
            try
            {
                var opcao = int.Parse(Console.ReadLine());

                var planoController = new PlanoController();
                var clienteController = new ClienteController();

                switch (opcao)
                {
                    case 1:
                        planoController.Cadastrar();
                        Main(args); //recursividade
                        break;
                    case 2:
                        planoController.Atualizar();
                        Main(args);
                        break;
                    case 3:
                        planoController.Excluir();
                        Main(args);
                        break;
                    case 4:
                        planoController.Consultar();
                        Main(args);
                        break;
                    case 5:
                        clienteController.Cadastrar();  
                        Main(args);
                        break;
                    case 6:
                        clienteController.Atualizar();
                        Main(args);
                        break;
                    case 7:
                        clienteController.Excluir();
                        Main(args);
                        break;
                    case 8:
                        clienteController.Consultar();
                        Main(args);
                        break;
                    case 0:
                        Console.WriteLine("\n FIM DO PROGRAMA!");
                        break;
                    default:
                        Console.WriteLine("\n OPÇÃO INVÁLIDA! \n");
                        Main(args);
                        break;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("\n OPÇÃO INVÁLIDA OU ERRO! \n");
                Main(args);
            }
           

           

        }
    }
}
