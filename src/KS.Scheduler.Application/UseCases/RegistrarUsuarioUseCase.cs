using KS.Scheduler.Application.DTOs.Auth;
using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;

namespace KS.Scheduler.Application.UseCases
{
    public class RegistrarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarUsuarioUseCase(
            IUsuarioRepository usuarioRepository,
            IAuthService authService,
            IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponse> Executar(RegistrarUsuarioRequest request)
        {
            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(request.Email);
            if (usuarioExistente != null)
                throw new Exception("Email já cadastrado");

            var senhaHash = _authService.GerarHash(request.Senha);

            var usuario = new Usuario(request.Nome, request.Email, request.Telefone, senhaHash);

            await _usuarioRepository.AdicionarAsync(usuario);
            await _unitOfWork.Commit();

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