using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using ProjetoAula04.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ProjetoAula04.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        public void Add(Cliente entity)
        {

            try
            {
                using (var connection = new SqlConnection(appsettings.ConnectionString))
                {
                    connection.Execute("SP_INSERIR_CLIENTE",
                        new
                        {
                            @NOME = entity.Nome,
                            @CPF = entity.Cpf,
                            @IDPLANO = entity.IdPlano
                        },
                        commandType: CommandType.StoredProcedure

                        );

                };
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    throw new Exception("Não é possível incluir cliente, pois CPF já existe.");
                }
                else
                {
                    throw new Exception($"Não foi possível realizar operação. {ex.Message}");
                }
            }
           



        }

        public void Delete(Cliente entity)
        {
            using (var connection = new SqlConnection(appsettings.ConnectionString))
            {
                connection.Execute("SP_EXCLUIR_CLIENTE",
                    new
                    {
                        @ID = entity.Id
                    },
                    commandType: CommandType.StoredProcedure

                    );

            };
        }

        public List<Cliente> GetAll()
        {
            using (var connection = new SqlConnection(appsettings.ConnectionString))
            {
                return connection.Query(
                    @" SELECT * 
                       FROM CLIENTE c
                       INNER JON PLANO p ON p.ID = c.ID_PLANO
                       ORDER BY c.NOME;
                     ", 
                      (Cliente c, Plano p) =>
                      {
                          c.Plano = p;
                          return c;
                      }, splitOn: "IdPlano" ).ToList();

            };
        }

        public Cliente? GetbyId(Guid id)
        {
            using (var connection = new SqlConnection(appsettings.ConnectionString))
            {
                return connection.Query(
                    @" SELECT * 
                       FROM CLIENTE c
                       INNER JON PLANO p ON p.ID = c.ID_PLANO
                       ORDER BY c.NOME;
                     ",
                      (Cliente c, Plano p) =>
                      {
                          c.Plano = p;
                          return c;
                      }, 
                      new { id },
                      splitOn: "IdPlano").FirstOrDefault();

            };
        }

        public void Update(Cliente entity)
        {
            using (var connection = new SqlConnection(appsettings.ConnectionString))
            {
                connection.Execute("SP_ALTERAR_CLIENTE",
                    new
                    {   @ID = entity.Id,
                        @NOME = entity.Nome,
                        @CPF = entity.Cpf,
                        @IDPLANO = entity.IdPlano
                    },
                    commandType: CommandType.StoredProcedure

                    );

            };
        }
    }
}
