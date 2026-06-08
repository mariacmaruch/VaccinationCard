using FluentValidation;

namespace VaccinationCard.Application.Commands.DeleteVacinacao
{
    public class DeleteVacinacaoCommandValidator : AbstractValidator<DeleteVacinacaoCommand>
    {
        public DeleteVacinacaoCommandValidator()
        {
            RuleFor(x => x.vacinacaoId)
                .GreaterThan(0)
                .WithMessage("O identificador da vacinação deve ser maior que zero.");
        }
    }
}
