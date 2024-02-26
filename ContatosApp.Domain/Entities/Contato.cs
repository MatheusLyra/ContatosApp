﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatosApp.Domain.Entities
{
    public class Contato
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public string? Telefone { get; set; }
        public DateTime? DataHoraCriacao { get; set; }

    }
}
