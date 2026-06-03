using MediatR;
using VaccinationCard.Application.Responses;

namespace VaccinationCard.Application.Commands.Login
{
    public record LoginCommand(string userName, string password) : IRequest<LoginResponse>;
}
