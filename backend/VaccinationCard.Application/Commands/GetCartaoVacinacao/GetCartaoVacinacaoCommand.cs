using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;

namespace VaccinationCard.Application.Commands.GetCartaoVacinacao
{
    public record GetCartaoVacinacaoCommand(int contaId) : IRequest<Result<GetCartaoVacinacaoResponse>>;
}
