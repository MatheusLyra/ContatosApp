using ContatosApp.Domain.Entities;
using ContatosApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Interfaces.Services
{
    public interface IContatoDomainService
    {
        void Cadastrar(Contato movimentacao);
        void Atualizar(Contato movimentacao);
        void Excluir(Guid idMovimentacao);

        List<Contato> GetAll();

        Contato? GetById(Guid id);
    }
}
