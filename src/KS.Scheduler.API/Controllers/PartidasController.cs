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
        private readonly CancelarPresencaUseCase _cancelarPresencaUseCase;
        private readonly ObterPartidaUseCase _obterPartidaUseCase;
        public PartidasController(
            ConfirmarPresencaUseCase confirmarPresencaUseCase,
            CancelarPresencaUseCase cancelarPresencaUseCase,
            ObterPartidaUseCase obterPartidaUseCase)
        {
            _confirmarPresencaUseCase = confirmarPresencaUseCase;
            _cancelarPresencaUseCase = cancelarPresencaUseCase;
            _obterPartidaUseCase = obterPartidaUseCase;
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

        [HttpPost]
        public async Task<IActionResult> CriarPartida([FromServices] CriarPartidaUseCase useCase, [FromBody] CriarPartidaInput input)
        {
            try
            {
                var partidaId = await useCase.Execute(input);
                return Ok(new { sucesso = true, partidaId = partidaId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, erro = ex.Message });
            }
        }

        [HttpDelete("cancelar-presenca")]
        public async Task<IActionResult> CancelarPresenca([FromBody] CancelarPresencaInput input)
        {
            try
            {
                await _cancelarPresencaUseCase.Execute(input);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPartida(Guid id)
        {
            try
            {
                var partida = await _obterPartidaUseCase.Execute(id);

                if (partida == null)
                    return NotFound(new { mensagem = "Partida não encontrada." });

                return Ok(partida);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}