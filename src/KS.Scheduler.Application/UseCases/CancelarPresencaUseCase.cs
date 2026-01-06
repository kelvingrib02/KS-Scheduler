using KS.Scheduler.Application.DTOs;
using KS.Scheduler.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace KS.Scheduler.Application.UseCases
{
    public class CancelarPresencaUseCase
    {
        private readonly IUnitOfWork _uow;

        public CancelarPresencaUseCase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Execute(CancelarPresencaInput input)
        {
            var partida = await _uow.Partidas.ObterPartidaComPresencas(input.PartidaId);
            if (partida == null)
                throw new Exception("Partida não encontrada.");

            var jogador = await _uow.Jogadores.ObterPorTelefone(input.TelefoneJogador);
            if (jogador == null)
                throw new Exception("Jogador não encontrado com esse telefone.");

            partida.RemoverJogador(jogador.Id);

            await _uow.Commit();
        }
    }
}