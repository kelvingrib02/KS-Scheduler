using KS.Scheduler.Application.DTOs;
using KS.Scheduler.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace KS.Scheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresencaController : ControllerBase
    {
        private readonly ConfirmarPresencaUseCase _confirmarPresencaUseCase;

        public PresencaController(ConfirmarPresencaUseCase confirmarPresencaUseCase)
        {
            _confirmarPresencaUseCase = confirmarPresencaUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Confirmar([FromBody] ConfirmarPresencaInput input)
        {
            try
            {
                var resultado = await _confirmarPresencaUseCase.Execute(input);
                return Ok(new { mensagem = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}