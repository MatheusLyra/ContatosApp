﻿namespace ContatosApp.Presentation.Models.Auth
{
    /// <summary>
    /// Modelo de dados para armazenar as informações
    /// do usuário autenticado
    /// </summary>
    public class UserAuthViewModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
    }
}
