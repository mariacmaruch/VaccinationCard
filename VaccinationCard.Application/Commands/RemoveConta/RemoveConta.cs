using MediatR;
using VaccinationCard.Application.Common;

namespace VaccinationCard.Application.Commands.RemoveConta
{
    public record RemoveContaCommand(int contaId) : IRequest<Result<bool>>;
}
