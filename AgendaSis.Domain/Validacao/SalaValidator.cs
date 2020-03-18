using AgendaSis.Domain.Entidades;
using FluentValidation;

namespace AgendaSis.Domain.Validacao
{
    public class SalaValidator : AbstractValidator<Sala>
    {
        public SalaValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("O nome da sala não pode ser vazia")
                .NotNull().WithMessage("O nome da sala não pode ser vazia")
                .MaximumLength(300).WithMessage("O nome da sala não pode ter mais que 300 caracteres");
            RuleFor(r => r.Capacidade)
                .NotNull().WithMessage("A capacidade da sala não pode ser nula")
                .GreaterThan(1).WithMessage("A sala deve ter pelo menos um lugar");
            RuleFor(r => r.Andar)
                .NotNull().WithMessage("O campo andar da sala não pode ser nulo");
        }
    }
}
