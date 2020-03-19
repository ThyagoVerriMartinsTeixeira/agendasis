using AgendaSis.Application.Models.Pessoas;
using AgendaSis.Application.Models.Salas;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaSis.Application.Models.Agendas
{
    public class AgendaResponseDto : AgendaBaseDto
    {
        public int Id { get; set; }

        public virtual PessoaResponseDto Pessoa { get; set; }
        public virtual SalaDto Sala { get; set; }
    }
}