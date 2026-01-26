using KS.Scheduler.Application.DTOs.Auth;
using KS.Scheduler.Domain.Interfaces;

namespace KS.Scheduler.Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public LoginUseCase(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }

        public async Task<LoginResponse> Executar(LoginRequest request)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario == null)
                throw new Exception("Email ou senha inválidos");

            var senhaValida = _authService.ValidarSenha(request.Senha, usuario.SenhaHash);

            if (!senhaValida)
                throw new Exception("Email ou senha inválidos");

            var token = _authService.GerarToken(usuario.Id, usuario.Email, usuario.Nome);

            return new LoginResponse
            {
                Token = token,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Expiracao = DateTime.UtcNow.AddHours(24)
            };
        }
    }
}