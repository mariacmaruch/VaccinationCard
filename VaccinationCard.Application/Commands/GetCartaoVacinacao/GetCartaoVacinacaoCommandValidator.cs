using FluentValidation;

namespace VaccinationCard.Application.Commands.GetCartaoVacinacao
{
    public class GetCartaoVacinacaoCommandValidator : AbstractValidator<GetCartaoVacinacaoCommand>
    {
        public GetCartaoVacinacaoCommandValidator()
        {
            RuleFor(x => x.contaId)
                .GreaterThan(0)
                .WithMessage("O identificador da conta deve ser maior que zero.");
        }
    }
}
