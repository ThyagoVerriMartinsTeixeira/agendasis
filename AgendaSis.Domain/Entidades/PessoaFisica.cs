using AgendaSis.Domain.Validacao;
using System;
using System.Threading.Tasks;

namespace AgendaSis.Domain.Entidades
{
    public class PessoaFisica : Pessoa
    {
        protected PessoaFisica() { }

        public PessoaFisica(
            string nome,
            string telefone,
            string endereco,
            string email,
            string cpf,
            int generoId,
            DateTime dataNascimento
        )
            : base(nome, telefone, endereco, email)
        {
            Cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            GeneroId = generoId;
            DataNascimento = dataNascimento;
        }

        public void UpdateValues(
            string nome,
            string telefone,
            string endereco,
            string email,
            string cpf,
            int generoId,
            DateTime dataNascimento
        )
        {
            UpdateValues(nome, telefone, endereco, email);
            Cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            GeneroId = generoId;
            DataNascimento = dataNascimento;
        }

        public async Task<FluentValidation.Results.ValidationResult> Validate()
        {
            var validator = new PessoaFisicaValidator();
            return await validator.ValidateAsync(this);
        }

        public string Cpf { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public int GeneroId { get; protected set; }

        public virtual Genero Genero { get; protected set; }
    }
}
