using ContatosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Interfaces.Repositories
{
    public interface IContatoRepository
    {
        void Add(Contato entity);
        void Update(Contato entity);
        void Delete(Guid id);
        List<Contato> GetAll();
        Contato? GetById(Guid id);

        List<Contato> Get(String nome);
    }
}
