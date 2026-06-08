using FluentValidation;

namespace VaccinationCard.Application.Commands.CreateVacinacao
{
    public class CreateVacinacaoCommandValidator : AbstractValidator<CreateVacinacaoCommand>
    {
        public CreateVacinacaoCommandValidator()
        {
            RuleFor(x => x.contaId)
                .GreaterThan(0)
                .WithMessage("Conta inválida.");

            RuleFor(x => x.vacinaId)
                .GreaterThan(0)
                .WithMessage("Vacina inválida.");

            RuleFor(x => x.dose)
                .GreaterThan(0)
                .WithMessage("Dose inválida.");
        }
    }
}
