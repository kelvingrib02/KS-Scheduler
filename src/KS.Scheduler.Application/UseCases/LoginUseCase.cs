using BCrypt.Net;
using KS.Scheduler.Application.DTOs.Auth;
using KS.Scheduler.Application.Interfaces;
using KS.Scheduler.Domain.Interfaces;

namespace KS.Scheduler.Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public LoginUseCase(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResponseDto> ExecutarAsync(LoginRequestDto request)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario == null)
                throw new Exception("Email ou senha inválidos.");

            var senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash);

            if (!senhaValida)
                throw new Exception("Email ou senha inválidos.");

            var token = _tokenService.GerarToken(usuario);

            return new LoginResponseDto
            {
                Token = token,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }
    }
}