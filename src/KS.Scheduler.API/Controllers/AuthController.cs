using KS.Scheduler.Application.DTOs.Auth;
using KS.Scheduler.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace KS.Scheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;

        public AuthController(LoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var result = await _loginUseCase.ExecutarAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { mensagem = ex.Message });
            }
        }
    }
}