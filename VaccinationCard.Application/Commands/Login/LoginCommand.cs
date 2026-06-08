using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;

namespace VaccinationCard.Application.Commands.Login
{
    public record LoginCommand(string userName, string cpfCnpj) : IRequest<Result<LoginResponse>>;
}
