using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Application.Commands.CreateVacinacao;
using VaccinationCard.Application.Commands.DeleteVacinacao;
using VaccinationCard.Application.Commands.GetCartaoVacinacao;

namespace VaccinationCard.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VacinacaoController : ControllerBase
    {
        private readonly IMediator _mediator;


        [HttpPost]
        public async Task<IActionResult> CreateVacinacao(CreateVacinacaoCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }


        [HttpGet]
        public async Task<IActionResult> GetCartaoVacinacao(GetCartaoVacinacaoCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteVacinacaoCommand(id));

            return result.Success ? NoContent() : BadRequest(result.Error);
        }
    }
}
