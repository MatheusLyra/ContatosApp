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

namespace ContatosApp.Infra.Data.Repositories
{
    public class UsuarioRepositoryDapper : IUsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            var query = @"
                INSERT INTO USUARIO	
                   (ID				        ,
	                NOME             	    ,
                    EMAIL                   ,
	                SENHA                   ,
                    DATAHORACRIACAO )
                VALUES
                   (NEWID()      	 ,
	                @Nome            ,
	                @Email           ,
                    @Senha           ,
	                GETDATE()		 )
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                connectionSettings.Execute(query, new
                {
                    @Nome = usuario.Nome,
                    @Email = usuario.Email,
                    @Senha = usuario.Senha
                });
            }
        }

        public void Update(Usuario usuario)
        {
            var query = @"
                UPDATE USUARIO SET	
	               NOME    = @Nome     ,
                   EMAIL   = @Email    ,
	               SENHA   = @Senha    
                WHERE ID = @Id
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                connectionSettings.Execute(query, new
                {
                    @Nome = usuario.Nome,
                    @Email = usuario.Email,
                    @Senha = usuario.Senha,
                    @Id = usuario.Id
                });
            }
        }

        public void Delete(Guid id)
        {
            var query = @"
                DELETE USUARIO 
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

        public Usuario? Get(string email)
        {
            var query = @"
                SELECT ID           ,
                       NOME         ,
                       EMAIL        ,
                       SENHA        ,
                       DATAHORACRIACAO
                  FROM USUARIO
                 WHERE EMAIL LIKE @Email
                 ORDER BY NOME
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                return connectionSettings.Query<Usuario>(query, new
                {
                    @Email = email
                }).FirstOrDefault();
            }

        }

        public Usuario? Get(string email, string senha)
        {
            var query = @"
                SELECT ID           ,
                       NOME         ,
                       EMAIL        ,
                       SENHA        ,
                       DATAHORACRIACAO
                  FROM USUARIO
                 WHERE EMAIL = @Email
                   AND SENHA = @Senha
                 ORDER BY NOME
            ";
            using (var connectionSettings = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                return connectionSettings.Query<Usuario>(query, new
                {
                    @Email = email,
                    @Senha = senha  
                }).FirstOrDefault();
            }
        }
    }
}
