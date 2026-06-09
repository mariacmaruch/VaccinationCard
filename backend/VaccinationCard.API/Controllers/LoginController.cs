using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Application.Commands.Login;
using VaccinationCard.Application.Commands.RemoveConta;
using VaccinationCard.Application.Commands.SignUp;

namespace VaccinationCard.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> RemoveConta([FromQuery] RemoveContaCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? NoContent() : BadRequest(result.Error);
        }
    }
}
