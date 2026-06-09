using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Interfaces;
using VaccinationCard.Application.Responses;
using VaccinationCard.Domain.Entities;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Result<SignUpResponse>>
    {
        private readonly IContaRepository _contaRepository;

        public SignUpCommandHandler(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<Result<SignUpResponse>> Handle(SignUpCommand request,CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _contaRepository.GetByCpfCnpjAsync(request.cpfCnpj);

                if (existingUser != null)
                    return Result<SignUpResponse>.Fail("Usuário já cadastrado.");

                var conta = new Conta
                {
                    CpfCnpj = request.cpfCnpj,
                    Nome = request.userName
                };

                var user = await _contaRepository.Create(conta);

                return Result<SignUpResponse>.Ok(new SignUpResponse(user.Nome, user.CpfCnpj));
            }
            catch (Exception ex)
            {
                return Result<SignUpResponse>.Fail(ex.Message);
            }
        }
    }
}
