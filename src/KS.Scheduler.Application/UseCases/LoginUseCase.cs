using KS.Scheduler.Application.DTOs.Auth;
using KS.Scheduler.Domain.Interfaces;

namespace KS.Scheduler.Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LoginResponse> ExecutarAsync(LoginRequest request, Func<Guid, string, string, string> gerarToken)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario == null)
                throw new Exception("Email ou senha inválidos.");

            var senhaValida = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash);

            if (!senhaValida)
                throw new Exception("Email ou senha inválidos.");

            var token = gerarToken(usuario.Id, usuario.Email, usuario.Nome);

            return new LoginResponse
            {
                Token = token,
                Nome = usuario.Nome,
                Email = usuario.Email,
                UsuarioId = usuario.Id
            };
        }
    }
}