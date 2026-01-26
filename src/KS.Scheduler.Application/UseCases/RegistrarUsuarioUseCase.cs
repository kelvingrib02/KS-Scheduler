using KS.Scheduler.Application.DTOs.Auth;
using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;
using BCrypt.Net;

namespace KS.Scheduler.Application.UseCases
{
    public class RegistrarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarUsuarioUseCase(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> ExecutarAsync(RegistrarUsuarioRequest request)
        {
            var emailExiste = await _usuarioRepository.EmailExisteAsync(request.Email);
            if (emailExiste)
                throw new Exception("Este email já está cadastrado.");

            var senhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

            var usuario = new Usuario(
                request.Nome,
                request.Email,
                request.Telefone,
                senhaHash
            );

            await _usuarioRepository.AdicionarAsync(usuario);
            await _unitOfWork.Commit();

            return usuario.Id;
        }
    }
}