using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KS.Scheduler.Application.UseCases
{
    public class ObterPartidaUseCase
    {
        private readonly IPartidaRepository _repository;

        public ObterPartidaUseCase(IPartidaRepository repository)
        {
            _repository = repository;
        }

        public async Task<object?> Execute(Guid id)
        {
            var partida = await _repository.ObterPorIdCompletoAsync(id);

            if (partida == null) return null;

            return new
            {
                partida.Id,
                partida.DataHora,
                partida.Local,
                partida.ValorPorPessoa,
                partida.MaximoJogadores,
                Presencas = partida.Presencas.Select(p => new
                {
                    p.Id,
                    Nome = p.Jogador.Nome,
                    p.Jogador.Posicao,
                    p.Jogador.Telefone,
                    p.Status
                }).ToList()
            };
        }
    }
}