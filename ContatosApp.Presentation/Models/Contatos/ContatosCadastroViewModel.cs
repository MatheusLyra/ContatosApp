using System.ComponentModel.DataAnnotations;

namespace ContatosApp.Presentation.Models.Contatos
{
    public class ContatosCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do contato.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email.")]
        [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone.")]
        public string? Telefone { get; set; }
    }
}
