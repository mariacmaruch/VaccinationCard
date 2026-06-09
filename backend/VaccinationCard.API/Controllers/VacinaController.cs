using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Application.Commands.CreateVacina;
using VaccinationCard.Application.Commands.GetAllVacinas;

namespace VaccinationCard.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class VacinaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacinaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacina(CreateVacinaCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacinas()
        {
            var result = await _mediator.Send(new GetAllVacinasCommand());

            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }
    }
}
