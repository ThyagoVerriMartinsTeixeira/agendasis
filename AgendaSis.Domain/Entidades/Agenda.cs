using AgendaSis.Domain.Validacao;
using System;
using System.Threading.Tasks;

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

        public DateTime Data { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int QuantidadePessoas { get; set; }

        public int SalaId { get; set; }
        public int PessoaId { get; set; }

        public async Task<FluentValidation.Results.ValidationResult> Validate()
        {
            var validator = new AgendaValidator();
            return await validator.ValidateAsync(this);
        }

        public virtual Sala Sala { get; protected set; }
        public virtual Pessoa Pessoa { get; protected set; }

        public void UpdateValues (DateTime data, DateTime horaInicio, DateTime horaFim, int salaId, int pessoaId, int quantidadePessoas)
        {
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            QuantidadePessoas = quantidadePessoas;
            SalaId = salaId;
            PessoaId = pessoaId;
        }
    }
}
