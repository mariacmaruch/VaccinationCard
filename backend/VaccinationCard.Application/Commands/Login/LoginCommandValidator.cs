using FluentValidation;

namespace VaccinationCard.Application.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.userName)
                .NotEmpty()
                .WithMessage("O nome do usuário é obrigatório.")
                .MaximumLength(150);

            RuleFor(x => x.cpfCnpj)
                .NotEmpty()
                .WithMessage("CPF/CNPJ é obrigatório.");
        }
    }
}
