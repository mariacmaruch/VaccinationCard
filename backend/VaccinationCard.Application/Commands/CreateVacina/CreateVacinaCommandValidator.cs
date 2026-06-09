using FluentValidation;

namespace VaccinationCard.Application.Commands.CreateVacina
{
    public class CreateVacinaCommandValidator : AbstractValidator<CreateVacinaCommand>
    {
        public CreateVacinaCommandValidator()
        {
            RuleFor(x => x.nomeVacina)
                .NotEmpty()
                .WithMessage("O nome da vacina é obrigatório.")
                .Length(3, 100);
        }
    }
}
