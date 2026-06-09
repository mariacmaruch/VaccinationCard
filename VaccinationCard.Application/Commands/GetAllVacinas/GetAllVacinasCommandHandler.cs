using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VaccinationCard.Application.Commands.CreateVacina;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;
using VaccinationCard.Domain.Entities;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.GetAllVacinas
{
    public class GetAllVacinasCommandHandler : IRequestHandler<GetAllVacinasCommand, Result<GetAllVacinasResponse>>
    {
        private readonly IVacinaRepository _vacinaRepository;

        public GetAllVacinasCommandHandler(IVacinaRepository vacinaRepository)
        {
            _vacinaRepository = vacinaRepository;
        }

        public async Task<Result<GetAllVacinasResponse>> Handle(GetAllVacinasCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                var vacinasExistentes = await _vacinaRepository.GetAll();

                if (vacinasExistentes == null || !vacinasExistentes.Any())
                    return Result<GetAllVacinasResponse>.Fail("Não há vacinas cadastradas.");

                var vacinas = vacinasExistentes.Select(v => new VacinaResponse(v.Id, v.Nome)).ToList();

                var response = new GetAllVacinasResponse(vacinas);

                return Result<GetAllVacinasResponse>.Ok(response);
            }
            catch (Exception ex)
            {
                return Result<GetAllVacinasResponse>.Fail(ex.Message);
            }
        }
    }
}
