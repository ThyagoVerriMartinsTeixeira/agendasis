using System;

namespace AgendaSis.Domain.Entidades
{
    public class Agenda : BaseEntity
    {
        protected Agenda() { }

        public Agenda(DateTime data, DateTime horaInicio, DateTime horaFim, int salaId, int pessoaId, int quantidadePessoas)
        {
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            QuantidadePessoas = quantidadePessoas;
            SalaId = salaId;
            PessoaId = pessoaId;
        }

        public DateTime Data { get; protected set; }
        public DateTime HoraInicio { get; protected set; }
        public DateTime HoraFim { get; protected set; }
        public int QuantidadePessoas { get; protected set; }

        public int SalaId { get; protected set; }
        public int PessoaId { get; protected set; }

        public virtual Sala Sala { get; protected set; }
        public virtual Pessoa Pessoa { get; protected set; }
    }
}
