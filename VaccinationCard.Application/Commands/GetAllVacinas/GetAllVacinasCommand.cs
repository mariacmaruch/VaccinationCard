using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;

namespace VaccinationCard.Application.Commands.GetAllVacinas
{
    public record GetAllVacinasCommand() : IRequest<Result<GetAllVacinasResponse>>;
}
