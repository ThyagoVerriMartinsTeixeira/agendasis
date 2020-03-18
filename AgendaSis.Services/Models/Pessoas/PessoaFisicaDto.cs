using System;

namespace AgendaSis.Application.Models.Pessoas
{
    public abstract class PessoaFisicaDto : PessoaBaseDto
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int GeneroId { get; set; }
    }
}
