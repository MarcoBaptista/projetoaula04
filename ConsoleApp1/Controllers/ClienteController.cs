using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using ProjetoAula04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    public class ClienteController : IController
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly PlanoRepository _planoRepository;

        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
            _planoRepository= new PlanoRepository();
        }    

        public void Atualizar()
        {
            try
            {
                Console.WriteLine("\n *** ATUALIZAR CLIENTE *** \n");
                Console.Write("INFORME ID DO CLIENTE.........: ");

                var IdCliente = Guid.Parse(Console.ReadLine());

                var cliente = _clienteRepository.GetbyId(IdCliente);

                if ( cliente == null)
                {
                    Console.WriteLine("ID CLIENTE NÃO EXISTE!");
                }
                else
                {
                    //Console.WriteLine("(1) ATUALIZAR NOME ");
                    //Console.WriteLine("(2) ATUALIZAR CPF  ");
                    //Console.Write("\nENTRE COM A OPÇÃO DESEJADA...: ");
                    //var opcao = int.Parse(Console.ReadLine());

                    //switch (opcao)
                    //{
                    //    case 1:
                    //        Console.Write("NOME DO CLIENTE.........: ");
                    //        cliente.Nome = Console.ReadLine();
                    //        break;
                    //    case 2:
                    //        Console.Write("CPF DO CLIENTE.........: ");
                    //        cliente.Cpf = Console.ReadLine();
                    //        break;
                    //    case 3:
                    //        Console.Write("CPF DO CLIENTE.........: ");
                    //        cliente.Cpf = Console.ReadLine();
                    //        break;
                    //    default:
                    //    Console.WriteLine("OPÇÃO INVÁLIDA!");
                    //    Atualizar();
                    //    break;

                    //}
                    Console.Write("NOME DO CLIENTE.........: ");
                    cliente.Nome = Console.ReadLine();
                    Console.Write("CPF DO CLIENTE.........: ");
                    cliente.Cpf = Console.ReadLine();
                    Console.Write("PLANO DO CLIENTE.........: ");
                    cliente.IdPlano = Guid.Parse(Console.ReadLine());

                    if (_planoRepository.GetbyId(cliente.IdPlano) != null)
                    {
                        _clienteRepository.Update(cliente);
                        Console.WriteLine("\n CLIENTE ATUALIZADO COM SUCESSO! \n");
                    }
                    else
                    {
                        Console.WriteLine("\n PLANO NÃO ENCONTRADO \n");
                    }

                    
                }
                

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao atualizar cliente: {ex.Message} ");
            }
        }

        public void Cadastrar()
        {
            try
            {
                Console.WriteLine("\n *** CADASTRO DE CLIENTE *** \n");
                var cliente = new Cliente();

                Console.Write("NOME DO CLIENTE.........: ");
                cliente.Nome = Console.ReadLine();

                Console.Write("CPF DO CLIENTE.........: ");
                cliente.Cpf = Console.ReadLine();

                Console.Write("ID DO PLANO............: ");
                var idPlano  = Guid.Parse(Console.ReadLine());
                
                if (_planoRepository.GetbyId(idPlano) == null)
                {
                    Console.WriteLine("\n PLANO NÃO ENCONTRADO \n");
                } else
                {
                    _clienteRepository.Add(cliente);
                    Console.WriteLine("\n CLIENTE CADASTRADO COM SUCESSO! \n");
                }

                

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao cadastrar cliente: {ex.Message} ");
            }
        }

        public void Consultar()
        {
            try
            {
                Console.WriteLine("\n *** LISTAR CLIENTES *** \n");

                var clientes = _clienteRepository.GetAll();
                foreach (var cliente in clientes) 
                { 
                    
                    Console.WriteLine($"ID DO CLIENTE.........: {cliente.Id}" );
                    Console.WriteLine($"NOME DO CLIENTE.......: {cliente.Nome}");
                    Console.WriteLine($"CPF...................: {cliente.Cpf}");
                    Console.WriteLine("-----------PLANO------------");
                    Console.WriteLine($"ID.................: {cliente.Plano.Id}");
                    Console.WriteLine($"NOME.................: {cliente.Plano.Nome}");
                    Console.WriteLine("..............................");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao consultar cliente: {ex.Message} ");
            }
        }

        public void Excluir()
        {
            try
            {
                Console.WriteLine("\n *** EXCLUIR CLIENTE *** \n");
          
                Console.Write("ID DO CLIENTE............: ");
                var id = Guid.Parse(Console.ReadLine());

                var cliente = _clienteRepository.GetbyId(id);
                if ( cliente == null)
                {
                    Console.WriteLine("\n CLIENTE NÃO ENCONTRADO \n");
                }
                else
                {
                    _clienteRepository.Delete(cliente);
                    Console.WriteLine("\n CLIENTE EXCLUÍDO COM SUCESSO! \n");
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao excluir cliente: {ex.Message} ");
            }
        }
    }
}
