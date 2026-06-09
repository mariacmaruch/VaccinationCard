using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.GetCartaoVacinacao
{
    public class GetCartaoVacinacaoCommandHandler : IRequestHandler<GetCartaoVacinacaoCommand, Result<GetCartaoVacinacaoResponse>>
    {
        private readonly IVacinacaoRepository _vacinacaoRepository;
        private readonly IContaRepository _contaRepository;

        public GetCartaoVacinacaoCommandHandler(IVacinacaoRepository vacinacaoRepository,IContaRepository contaRepository)
        {
            _vacinacaoRepository = vacinacaoRepository;
            _contaRepository = contaRepository;
        }

        public async Task<Result<GetCartaoVacinacaoResponse>> Handle(GetCartaoVacinacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var conta = await _contaRepository.GetByIdAsync(request.contaId);

                if (conta == null)
                    return Result<GetCartaoVacinacaoResponse>.Fail("Conta não encontrada.");

                var vacinacoes = await _vacinacaoRepository.GetByContaIdAsync(request.contaId);

                var response = new GetCartaoVacinacaoResponse(
                    conta.Id,
                    conta.Nome,
                    vacinacoes.Select(x =>
                        new CartaoVacinacaoItemResponse(
                            x.Id,
                            x.Vacina.Nome,
                            x.Dose,
                            x.DataAplicacao
                        )
                    ).ToList()
                );

                return Result<GetCartaoVacinacaoResponse>.Ok(response);
            }
            catch (Exception ex)
            {
                return Result<GetCartaoVacinacaoResponse>.Fail(ex.Message);
            }
        }
    }
}
