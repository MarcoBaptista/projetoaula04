using Dapper;
using ProjetoAula04.Entities;
using ProjetoAula04.Interfaces;
using ProjetoAula04.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ProjetoAula04.Repositories
{
    public class PlanoRepository : IRepository<Plano>
    {
        public void Add(Plano entity)
        {
            using (var connection = new SqlConnection(appsettings.ConnectionString)) 
            {
                connection.Execute("SP_INSERIR_PLANO",
                    new { @NOME  = entity.Nome }, 
                    commandType: CommandType.StoredProcedure
                    
                    );
            
            };
        }

        public void Delete(Plano entity)
        {

            try
            {
                using (var connection = new SqlConnection(appsettings.ConnectionString))
                {
                    connection.Execute("SP_EXCLUIR_PLANO",
                        new
                        {
                            @ID = entity.Id
                        },
                        commandType: CommandType.StoredProcedure);

                };
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) 
                {
                    throw new Exception("Não é possível excluir o plano, pois possui clientes vinculados.");
                }
                else
                {
                    throw new Exception($"Não foi possível excluir plano. {ex.Message}");
                }
                
            }

         
        }

        public List<Plano> GetAll()
        {
            using (var connection = new SqlConnection(appsettings.ConnectionString))
            {
               return connection.Query<Plano>(
                   @"SELECT * FROM PLANO ORDER BY NOME;"
                   ).ToList();
               
            };
        }

        public Plano? GetbyId(Guid id)
        {
            using (var connection = new SqlConnection(appsettings.ConnectionString))
            {
                return connection.Query<Plano>(
                    @"SELECT * FROM PLANO WHERE ID = @id ;", 
                        new {@ID = id }
                    ).FirstOrDefault();

            };
        }

        public void Update(Plano entity)
        {
            using (var connection = new SqlConnection(appsettings.ConnectionString))
            {
                connection.Execute("SP_ALTERAR_PLANO",
                    new { @ID = entity.Id,
                          @NOME = entity.Nome
                    },
                    commandType: CommandType.StoredProcedure

                    );

            };
        }
    }
}
