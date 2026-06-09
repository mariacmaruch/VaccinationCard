using MediatR;
using VaccinationCard.Application.Common;

namespace VaccinationCard.Application.Commands.DeleteVacinacao
{
    public record DeleteVacinacaoCommand(int vacinacaoId) : IRequest<Result<bool>>;
}
