using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;
using VaccinationCard.Domain.Entities;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.CreateVacina
{
    public class CreateVacinaCommandHandler : IRequestHandler<CreateVacinaCommand, Result<CreateVacinaResponse>>
    {
        private readonly IVacinaRepository _vacinaRepository;

        public CreateVacinaCommandHandler(IVacinaRepository vacinaRepository)
        {
            _vacinaRepository = vacinaRepository;
        }

        public async Task<Result<CreateVacinaResponse>> Handle(CreateVacinaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vacinaExistente = await _vacinaRepository.GetByNomeAsync(request.nomeVacina);

                if (vacinaExistente != null)
                {
                    return Result<CreateVacinaResponse>.Fail("Vacina já cadastrada.");
                }

                var vacina = new Vacina
                {
                    Nome = request.nomeVacina
                };

                await _vacinaRepository.Create(vacina);

                return Result<CreateVacinaResponse>.Ok(new CreateVacinaResponse(vacina.Nome));
            }
            catch (Exception ex)
            {
                return Result<CreateVacinaResponse>.Fail(ex.Message);
            }
        }
    }
}
