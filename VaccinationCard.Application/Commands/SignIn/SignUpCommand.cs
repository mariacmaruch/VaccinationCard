using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;

namespace VaccinationCard.Application.Commands.SignUp
{
    public record SignUpCommand(string userName, string cpfCnpj) : IRequest<Result<SignUpResponse>>;
}
