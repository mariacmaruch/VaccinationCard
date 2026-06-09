using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Application.Commands.CreateVacinacao;
using VaccinationCard.Application.Commands.DeleteVacinacao;
using VaccinationCard.Application.Commands.GetCartaoVacinacao;

namespace VaccinationCard.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class VacinacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacinacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacinacao(CreateVacinacaoCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }


        [HttpGet]
        public async Task<IActionResult> GetCartaoVacinacao([FromQuery] GetCartaoVacinacaoCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteVacinacaoCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? NoContent() : BadRequest(result.Error);
        }
    }
}
