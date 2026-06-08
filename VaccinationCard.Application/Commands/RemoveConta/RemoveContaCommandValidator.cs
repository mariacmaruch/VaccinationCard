using FluentValidation;

namespace VaccinationCard.Application.Commands.RemoveConta
{
    public class RemoveContaCommandValidator : AbstractValidator<RemoveContaCommand>
    {
        public RemoveContaCommandValidator()
        {
            RuleFor(x => x.contaId)
                .GreaterThan(0)
                .WithMessage("O identificador da conta deve ser maior que zero.");
        }
    }
}
