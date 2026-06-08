using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.DeleteVacinacao
{
    public class DeleteVacinacaoCommandHandler : IRequestHandler<DeleteVacinacaoCommand, Result<bool>>
    {
        private readonly IVacinacaoRepository _vacinacaoRepository;

        public DeleteVacinacaoCommandHandler(IVacinacaoRepository vacinacaoRepository)
        {
            _vacinacaoRepository = vacinacaoRepository;
        }

        public async Task<Result<bool>> Handle(DeleteVacinacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vacinacao = await _vacinacaoRepository.GetByIdAsync(request.vacinacaoId);

                if (vacinacao == null)
                    return Result<bool>.Fail("Registro de vacinação não encontrado.");

                await _vacinacaoRepository.DeleteAsync(request.vacinacaoId);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail(ex.Message);
            }
        }
    }
}
