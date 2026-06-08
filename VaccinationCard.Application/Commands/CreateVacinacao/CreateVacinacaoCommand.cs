using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;

namespace VaccinationCard.Application.Commands.CreateVacinacao
{
    public record CreateVacinacaoCommand(int contaId, int vacinaId, int dose) : IRequest<Result<CreateVacinacaoResponse>>;
}
