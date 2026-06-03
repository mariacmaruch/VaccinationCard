using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Application.Commands.Login;

namespace VaccinationCard.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        [HttpPost]
        public async Task<ActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
