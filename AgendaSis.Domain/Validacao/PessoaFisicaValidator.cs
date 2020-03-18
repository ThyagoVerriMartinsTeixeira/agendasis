using AgendaSis.Domain.Entidades;
using FluentValidation;

namespace AgendaSis.Domain.Validacao
{
    public class PessoaFisicaValidator : AbstractValidator<PessoaFisica>
    {
        public PessoaFisicaValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("O nome da pessoa física deve ser informado")
                .NotNull().WithMessage("O nome da pessoa física deve ser informado")
                .MaximumLength(300).WithMessage("O nome da pessoa física não pode ter mais que 300 caracteres");
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("O email da pessoa física deve ser informado")
                .NotNull().WithMessage("O email da pessoa física deve ser informado")
                .EmailAddress().WithMessage("Email inválido");
            RuleFor(r => r.Cpf)
                .NotEmpty().WithMessage("O cpf da pessoa física deve ser informado")
                .NotNull().WithMessage("O cpf da pessoa física deve ser informado")
                .MaximumLength(11).WithMessage("O cpf da pessoa física não pode ter mais que 11 caracteres")
                .Must(ValidaCPF).WithMessage("O cpf está inválido");
            RuleFor(r => r.DataNascimento)
                .NotNull().WithMessage("O data de nascimento da pessoa física deve ser informada");
            RuleFor(r => r.GeneroId)
                .NotNull().WithMessage("O genero da pessoa física deve ser informado")
                .GreaterThan(0).WithMessage("O genero informado é inválido");
            // outras validações omitidas propositalmente
        }

        public bool ValidaCPF(string cpf)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
