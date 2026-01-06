using KS.Scheduler.Application.DTOs;
using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Enums;
using KS.Scheduler.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace KS.Scheduler.Application.UseCases
{
    public class CriarPartidaUseCase
    {
        private readonly IPartidaRepository _partidaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CriarPartidaUseCase(IPartidaRepository partidaRepository, IUnitOfWork unitOfWork)
        {
            _partidaRepository = partidaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Execute(CriarPartidaInput input)
        {
            var tipoJogoEnum = (TipoJogo)input.TipoJogo;

            var partida = new Partida(
                input.DataHora,
                input.Local,
                input.MaximoJogadores,
                tipoJogoEnum,
                input.ValorTotal,
                input.ValorPorPessoa
            );

            await _partidaRepository.CriarAsync(partida);

            await _unitOfWork.Commit();

            return partida.Id;
        }
    }
}
