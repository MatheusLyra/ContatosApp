using System.ComponentModel.DataAnnotations;

namespace ContatosApp.Presentation.Models.Contatos
{
    public class ContatosEdicaoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome da movimentação.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email.")]
        [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone.")]
        public string? Telefone { get; set; }
    }
}
