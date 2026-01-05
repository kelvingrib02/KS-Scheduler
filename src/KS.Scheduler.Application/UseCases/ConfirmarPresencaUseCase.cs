using KS.Scheduler.Application.DTOs;
using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace KS.Scheduler.Application.UseCases
{
    public class ConfirmarPresencaUseCase : IConfirmarPresencaUseCase
    {
        private readonly IUnitOfWork _uow;
        public ConfirmarPresencaUseCase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Execute(ConfirmarPresencaInput input)
        {
            var partida = await _uow.Partidas.ObterPorId(input.PartidaId);
            if (partida == null)
                throw new Exception("Partida não encontrada.");

            var jogador = await _uow.Jogadores.ObterPorId(input.JogadorId);
            if (jogador == null)
                throw new Exception("Jogador não encontrado.");

            var novaPresenca = new Presenca(partida.Id, jogador.Id);

            novaPresenca.Confirmar();

            await _uow.Presencas.Adicionar(novaPresenca);

            await _uow.Commit();
        }
    }
}