using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Interfaces.Repositories;
using ContatosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Services
{
    public class ContatoDomainService : IContatoDomainService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoDomainService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Cadastrar(Contato entity)
        {
            _contatoRepository.Add(entity);
        }

        public void Atualizar(Contato entity)
        {
            if (_contatoRepository?.GetById(entity.Id.Value) == null)
              throw new ApplicationException("O Contato informado não existe. Por favor, verifique.");

            _contatoRepository.Update(entity);
        }

        public void Excluir(Guid id)
        {
            if (_contatoRepository?.GetById(id) == null)
                throw new ApplicationException("O Contato informado não existe. Por favor, verifique.");

            _contatoRepository.Delete(id);  
        }

        public List<Contato> GetAll()
        {
            return _contatoRepository.GetAll();
        }

        public Contato? GetById(Guid id)
        {
            return _contatoRepository?.GetById(id);
        }

        public List<Contato> Consultar(string nome)
        {
            return _contatoRepository?.Get(nome);
        }
    }
}
