using System;

namespace AgendaSis.Application.Models.Pessoas
{
    public abstract class PessoaJuridicaDto : PessoaBaseDto
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataAbertura { get; set; }
    }
}
