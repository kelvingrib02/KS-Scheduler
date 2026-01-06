using KS.Scheduler.Application.DTOs;
using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Enums;
using KS.Scheduler.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace KS.Scheduler.Application.UseCases
{
    public class ConfirmarPresencaUseCase
    {
        private readonly IUnitOfWork _uow;

        public ConfirmarPresencaUseCase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Guid> Execute(ConfirmarPresencaInput input)
        {
            var partida = await _uow.Partidas.ObterPartidaComPresencas(input.PartidaId);

            if (partida == null)
                throw new Exception("Partida não encontrada.");

            if (partida.Presencas.Count >= partida.MaximoJogadores)
                throw new Exception("A lista já está cheia! Entre na fila de espera.");

            var jogador = await _uow.Jogadores.ObterPorTelefone(input.TelefoneJogador);

            if (jogador == null)
            {
                jogador = new Jogador(input.NomeJogador, input.TelefoneJogador, input.Posicao, NivelHabilidade.Iniciante);
            }

            partida.AdicionarJogador(jogador);

            await _uow.Commit();

            return jogador.Id;
        }
    }
}