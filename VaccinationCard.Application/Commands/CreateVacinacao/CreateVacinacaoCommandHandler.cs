using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VaccinationCard.Application.Commands.Login;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Interfaces;
using VaccinationCard.Application.Responses;
using VaccinationCard.Domain.Entities;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.CreateVacinacao
{
    public class CreateVacinacaoCommandHandler : IRequestHandler<CreateVacinacaoCommand, Result<CreateVacinacaoResponse>>
    {
        private readonly IVacinaRepository _vacinaRepository;
        private readonly IVacinacaoRepository _vacinacaoRepository;

        public CreateVacinacaoCommandHandler(IVacinaRepository vacinaRepository, IVacinacaoRepository vacinacaoRepository)
        {
            _vacinaRepository = vacinaRepository;
            _vacinacaoRepository = vacinacaoRepository;
        }

        public async Task<Result<CreateVacinacaoResponse>> Handle(CreateVacinacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vacina = await _vacinaRepository.GetByIdAsync(request.vacinaId);

                if (vacina == null)
                    return Result<CreateVacinacaoResponse>.Fail("Vacina não encontrada.");

                var ultimaDose = await _vacinacaoRepository.GetUltimaDoseAsync(request.contaId, request.vacinaId);

                var proximaDose = ultimaDose + 1;

                if (request.dose != proximaDose)
                {
                    return Result<CreateVacinacaoResponse>.Fail($"Dose inválida. Esperada: {proximaDose}");
                }

                var vacinacao = new Vacinacao
                {
                    ContaId = request.contaId,
                    VacinaId = request.vacinaId,
                    Dose = request.dose,
                    DataAplicacao = DateTime.UtcNow
                };

                var criada = await _vacinacaoRepository.Create(vacinacao);

                return Result<CreateVacinacaoResponse>.Ok(new CreateVacinacaoResponse(criada.Id, criada.ContaId, criada.VacinaId, criada.Dose, criada.DataAplicacao));
            }
            catch (Exception ex)
            {
                return Result<CreateVacinacaoResponse>.Fail(ex.Message);
            }
        }
    }
}
