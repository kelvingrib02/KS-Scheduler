using KS.Scheduler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KS.Scheduler.Domain.Interfaces
{
    public interface IPresencaRepository : IRepository<Presenca>
    {
        Task<IEnumerable<Presenca>> ObterPorJogador(Guid jogadorId);
        Task<IEnumerable<Presenca>> ObterConfirmadosPorPartida(Guid partidaId);
    }
}