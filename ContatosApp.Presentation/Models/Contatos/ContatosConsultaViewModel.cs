using ContatosApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ContatosApp.Presentation.Models.Contatos
{
    public class ContatosConsultaViewModel
    {
        public String? Nome { get; set; }
        public List<Contato>? ListagemContatos { get; set; }
    
    }
}
