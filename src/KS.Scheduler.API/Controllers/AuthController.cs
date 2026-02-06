using KS.Scheduler.API.Services;
using KS.Scheduler.Application.DTOs.Auth;
using KS.Scheduler.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace KS.Scheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RegistrarUsuarioUseCase _registrarUsuarioUseCase;
        private readonly LoginUseCase _loginUseCase;
        private readonly TokenService _tokenService;

        public AuthController(
            RegistrarUsuarioUseCase registrarUsuarioUseCase,
            LoginUseCase loginUseCase,
            TokenService tokenService)
        {
            _registrarUsuarioUseCase = registrarUsuarioUseCase;
            _loginUseCase = loginUseCase;
            _tokenService = tokenService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarUsuarioRequest request)
        {
            try
            {
                var usuarioId = await _registrarUsuarioUseCase.Executar(request);
                return Ok(new { UsuarioId = usuarioId, Mensagem = "Usuário cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _loginUseCase.Executar(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }
    }
}
