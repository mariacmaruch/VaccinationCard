using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;

namespace VaccinationCard.Application.Commands.CreateVacina
{
    public record CreateVacinaCommand(string nomeVacina) : IRequest<Result<CreateVacinaResponse>>;
}
