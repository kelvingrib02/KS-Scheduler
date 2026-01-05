using Microsoft.AspNetCore.Mvc;
using KS.Scheduler.Application.DTOs;
using KS.Scheduler.Application.UseCases;
using System.Threading.Tasks;
using System;

namespace KS.Scheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidasController : ControllerBase
    {
        private readonly ConfirmarPresencaUseCase _confirmarPresencaUseCase;

        public PartidasController(ConfirmarPresencaUseCase confirmarPresencaUseCase)
        {
            _confirmarPresencaUseCase = confirmarPresencaUseCase;
        }

        [HttpPost("confirmar-presenca")]
        public async Task<IActionResult> ConfirmarPresenca([FromBody] ConfirmarPresencaInput input)
        {
            try
            {
                var idPresenca = await _confirmarPresencaUseCase.Execute(input);

                return Ok(new
                {
                    sucesso = true,
                    mensagem = "Presença confirmada com sucesso!",
                    id = idPresenca
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    sucesso = false,
                    erro = ex.Message
                });
            }
        }
    }
}