using FluentValidation;
using VaccinationCard.Application.Commands.SignUp;

namespace VaccinationCard.Application.Commands.SignIn
{
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(x => x.userName)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .MaximumLength(150)
                .WithMessage("O nome deve ter no máximo 150 caracteres.");

            RuleFor(x => x.cpfCnpj)
                .NotEmpty()
                .WithMessage("CPF/CNPJ é obrigatório.");
        }
    }
}
