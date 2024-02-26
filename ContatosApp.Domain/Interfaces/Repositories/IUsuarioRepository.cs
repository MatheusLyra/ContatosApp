using ContatosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para repositório de usuário
    /// </summary>
    public interface IUsuarioRepository 
    {
        void Add(Usuario entity);
        void Update(Usuario entity);
        void Delete(Guid id);
        Usuario? Get(string email);
        Usuario? Get(string email, string senha);
    }
}
