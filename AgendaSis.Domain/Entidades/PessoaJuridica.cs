using AgendaSis.Domain.Validacao;
using System;
using System.Threading.Tasks;

namespace AgendaSis.Domain.Entidades
{
    public class PessoaJuridica : Pessoa
    {
        protected PessoaJuridica() { }

        public PessoaJuridica(string nome, string telefone, string endereco, string email, string cnpj, string razaoSocial, DateTime dataAbertura)
            : base(nome, telefone, endereco, email)
        {
            Cnpj = cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
            RazaoSocial = razaoSocial;
            DataAbertura = dataAbertura;
        }

        public void UpdateValues(string nome, string telefone, string endereco, string email, string cnpj, string razaoSocial, DateTime dataAbertura)
        {
            UpdateValues(nome, telefone, endereco, email);
            Cnpj = cnpj.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
            RazaoSocial = razaoSocial;
            DataAbertura = dataAbertura;
        }

        public async Task<FluentValidation.Results.ValidationResult> Validate()
        {
            var validator = new PessoaJuridicaValidator();
            return await validator.ValidateAsync(this);
        }

        public string Cnpj { get; protected set; }
        public string RazaoSocial { get; protected set; }
        public DateTime DataAbertura { get; protected set; }
    }
}
