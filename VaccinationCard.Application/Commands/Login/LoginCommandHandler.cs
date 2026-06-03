using MediatR;
using VaccinationCard.Application.Interfaces;
using VaccinationCard.Application.Responses;
using VaccinationCard.Domain.Interfaces;

namespace VaccinationCard.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IContaRepository _contaRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(IContaRepository contaRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _contaRepository = contaRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _contaRepository.GetByUserNameAsync(request.userName);

            if (user is null)
                throw new UnauthorizedAccessException();

            var token = _jwtTokenGenerator.GenerateToken(user.Identificador, user.Name);

            return new LoginResponse(token);
        }
    }
}
