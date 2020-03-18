using AgendaSis.Domain.Entidades;
using FluentValidation;
using System;

namespace AgendaSis.Domain.Validacao
{
    public class PessoaJuridicaValidator : AbstractValidator<PessoaJuridica>
    {
        public PessoaJuridicaValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("O nome da pessoa jurídica deve ser informado")
                .NotNull().WithMessage("O nome da pessoa jurídica deve ser informado")
                .MaximumLength(300).WithMessage("O nome da pessoa jurídica não pode ter mais que 300 caracteres");
            RuleFor(r => r.RazaoSocial)
                .NotEmpty().WithMessage("O razão social da pessoa jurídica deve ser informado")
                .NotNull().WithMessage("O razão social da pessoa jurídica deve ser informado")
                .MaximumLength(300).WithMessage("O razão social da pessoa jurídica não pode ter mais que 300 caracteres");
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("O email da pessoa jurídica deve ser informado")
                .NotNull().WithMessage("O email da pessoa jurídica deve ser informado")
                .EmailAddress().WithMessage("Email inválido");
            RuleFor(r => r.Cnpj)
                .NotEmpty().WithMessage("O cnpj da pessoa jurídica deve ser informado")
                .NotNull().WithMessage("O cnpj da pessoa jurídica deve ser informado")
                .MaximumLength(14).WithMessage("O cnpj da pessoa jurídica não pode ter mais que 14 caracteres")
                .Must(ValidaCNPJ).WithMessage("O cnpj é inválido");
            RuleFor(r => r.DataAbertura)
                .NotNull().WithMessage("O data de abertura da pessoa jurídica deve ser informada");
            // outras validações omitidas propositalmente
        }

        private bool ValidaCNPJ(string cnpj)
        {
            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
