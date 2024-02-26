using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Interfaces.Repositories;
using ContatosApp.Infra.Data.Contexts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ContatosApp.Infra.Data.Repositories
{
    public class ContatoRepositoryDapper : IContatoRepository
    {
        public void Add(Contato entity)
        {
            var query = @"
                INSERT INTO CONTATO	
                   (ID				        ,
	                NOME             	    ,
                    EMAIL                   ,
	                TELEFONE                ,
                    DATAHORACRIACAO )
                VALUES
                   (NEWID()      	 ,
	                @Nome            ,
	                @Email           ,
                    @Telefone        ,
	                GETDATE()		 )
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                connectionSettings.Execute(query, new
                {
                    @Nome = entity.Nome,
                    @Email = entity.Email,
                    @Telefone = entity.Telefone
                });
            }
        }

        public void Update(Contato entity)
        {
            var query = @"
                UPDATE CONTATO SET	
	                NOME      = @Nome      ,
                    EMAIL     = @Email     ,
	                TELEFONE  = @Telefone  
                WHERE ID = @Id
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                connectionSettings.Execute(query, new
                {
                    @Nome = entity.Nome,
                    @Email = entity.Email,
                    @Telefone = entity.Telefone,
                    @Id    = entity.Id
                });
            }
        }

        public void Delete(Guid id)
        {
            var query = @"
                DELETE CONTATO 
                 WHERE ID = @Id
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                connectionSettings.Execute(query, new
                {
                    @Id = id
                });
            }
        }

        public List<Contato> GetAll()
        {
            var query = @"
                SELECT ID           ,
                       NOME         ,
                       EMAIL        ,
                       TELEFONE     ,
                       DATAHORACRIACAO
                  FROM CONTATO
                 ORDER BY NOME
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                return connectionSettings.Query< Contato>(query).ToList();
            }
        }

        public Contato? GetById(Guid id)
        {
            var query = @"
                SELECT ID           ,
                       NOME         ,
                       EMAIL        ,
                       TELEFONE     ,
                       DATAHORACRIACAO
                  FROM CONTATO
                 WHERE ID = @Id
                 ORDER BY NOME
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                return connectionSettings.Query<Contato>(query, new
                {
                    @Id = id
                }).FirstOrDefault();
            }
        }

        public List<Contato> Get(String nome)
        {
            var query = @"
                SELECT ID           ,
                       NOME         ,
                       EMAIL        ,
                       TELEFONE     ,
                       DATAHORACRIACAO
                  FROM CONTATO
                 WHERE UPPER(NOME) LIKE @Nome 
                 ORDER BY NOME
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                return connectionSettings.Query<Contato>(query, new { @Nome = "%" + nome + "%" }).ToList();
            }
        }
    }
}
