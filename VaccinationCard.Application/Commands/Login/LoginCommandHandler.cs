using MediatR;
using VaccinationCard.Application.Common;
using VaccinationCard.Application.Interfaces;
using VaccinationCard.Application.Responses;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponse>>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(
            IContaRepository contaRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _contaRepository = contaRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _contaRepository.GetByUserNameAsync(request.userName);

                if (user is null)
                    return Result<LoginResponse>.Fail("Usuário não encontrado.");

                var token = _jwtTokenGenerator.GenerateToken(user.Identificador,user.Nome, user.Id);

                return Result<LoginResponse>.Ok(new LoginResponse(token));
            }
            catch (Exception ex)
            {
                return Result<LoginResponse>.Fail(ex.Message);
            }
        }
    }
}