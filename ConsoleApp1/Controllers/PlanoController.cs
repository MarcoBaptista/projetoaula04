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
    public class PlanoController : IController
    {
        //atributo
        private readonly PlanoRepository _planoRepository;

        //método construtor
        public PlanoController()
        {
           _planoRepository = new PlanoRepository();
        }

        public void Atualizar()
        {

            try
            {
                Console.WriteLine("\n *** ATUALIZAR PLANO *** \n");
                
                Console.Write("INFORME ID DO PLANO...........: ");

                var id = Guid.Parse(Console.ReadLine());

               
                var plano = _planoRepository.GetbyId(id);

                if (plano != null) {

                    Console.Write("ALTERE O NOME DO PLANO...: ");
                    plano.Nome = Console.ReadLine();

                    _planoRepository.Update(plano);
                    Console.WriteLine("\n PLANO ATUALIZADO COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\n PLANO NÃO ENCONTRADO!");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao atualizar plano: {ex.Message} ");
            }
        }

        public void Cadastrar()
        {

            try
            {
                Console.WriteLine("\n *** CADASTRO DE PLANO *** \n");
                var plano = new Plano();

                Console.Write("NOME DO PLANO.........: ");
                plano.Nome = Console.ReadLine();

                _planoRepository.Add(plano);

                Console.WriteLine("\n PLANO CADASTRADO COM SUCESSO \n");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao cadastrar plano: {ex.Message} ");
            }
        }

        public void Consultar()
        {

            try
            {
                Console.WriteLine("\n *** CONSULTAR PLANOS *** \n");
              
                var planos = _planoRepository.GetAll();

                foreach (var item in planos)
                {
                    Console.WriteLine($"#------------------------------------#");
                    Console.WriteLine($"ID DO PLANO...........: {item.Id}");
                    Console.WriteLine($"NOME..................: {item.Nome}");
                  
                }
                

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao consultar planos: {ex.Message} ");
            }

        }

        public void Excluir()
        {
            try
            {
                Console.WriteLine("\n *** EXCLUIR PLANO *** \n");

                Console.Write("INFORME ID DO PLANO...........: ");

                var id = Guid.Parse(Console.ReadLine());

               
                var plano = _planoRepository.GetbyId(id);

                if (plano != null)
                {

                    _planoRepository.Delete(plano);
                    Console.WriteLine("\n PLANO EXCLUÍDO COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\n PLANO NÃO ENCONTRADO!");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Falha ao excluir plano: {ex.Message} ");
            }
        }
    }
}
