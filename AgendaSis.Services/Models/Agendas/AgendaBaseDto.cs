using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaSis.Application.Models.Agendas
{
    public abstract class AgendaBaseDto
    {
        public string Data { get;  set; }
        public string HoraInicio { get;  set; }
        public string HoraFim { get;  set; }
        public int QuantidadePessoas { get;  set; }
        public int SalaId { get;  set; }
        public int PessoaId { get;  set; }
    }
}
