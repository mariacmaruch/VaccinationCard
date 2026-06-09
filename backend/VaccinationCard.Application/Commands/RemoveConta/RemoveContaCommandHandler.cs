using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Responses;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.RemoveConta
{
    public class RemoveContaCommandHandler : IRequestHandler<RemoveContaCommand, Result<bool>>
    {
        private readonly IContaRepository _contaRepository;

        public RemoveContaCommandHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<Result<bool>> Handle(RemoveContaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pessoa = await _contaRepository.GetByIdAsync(request.contaId);

                if (pessoa == null)
                    return Result<bool>.Fail("Conta não encontrada.");

                await _contaRepository.Remove(pessoa.Id);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Fail(ex.Message);
            }
        }
    }
}
