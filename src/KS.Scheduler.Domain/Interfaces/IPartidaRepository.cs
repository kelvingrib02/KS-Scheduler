using KS.Scheduler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KS.Scheduler.Domain.Interfaces
{
    public interface IPartidaRepository : IRepository<Partida>
    {
        Task<Partida> ObterPartidaComPresencas(Guid id);
        Task<IEnumerable<Partida>> ObterPartidasPorData(DateTime inicio, DateTime fim);
        Task CriarAsync(Partida partida);
    }
}