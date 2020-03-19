using AgendaSis.Domain.Entidades;
using FluentValidation;

namespace AgendaSis.Domain.Validacao
{
    public class AgendaValidator : AbstractValidator<Agenda>
    {
        public AgendaValidator()
        {
            RuleFor(r => r.Data)
                .NotNull().WithMessage("O data do agendamento deve ser informada");
            RuleFor(r => r.QuantidadePessoas)
                .NotNull().WithMessage("A quantidade de pessoa deve ser informado");
            RuleFor(r => r.HoraInicio)
                .NotNull().WithMessage("A hora do agendamento ser informado");
            RuleFor(r => r.HoraFim)
                .NotNull().WithMessage("A hora do fim deve ser informado");
            RuleFor(r => r.SalaId)
                .NotNull().WithMessage("A sala deve ser informado")
                .GreaterThan(0).WithMessage("A sala informada é inválido");
            RuleFor(r => r.PessoaId)
                .NotNull().WithMessage("A pessoa deve ser informado")
               .GreaterThan(0).WithMessage("A pessoa informada é inválido");
        }
    }
}