using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KS.Scheduler.Infrastructure.Repositories
{
    public class PresencaRepository : Repository<Presenca>, IPresencaRepository
    {
        public PresencaRepository(KSSchedulerDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Presenca>> ObterPorJogador(Guid jogadorId)
        {
            return await DbSet.AsNoTracking().Where(p => p.JogadorId == jogadorId).Include(p => p.Partida).ToListAsync();
        }
        public async Task<IEnumerable<Presenca>> ObterConfirmadosPorPartida(Guid partidaId)
        {
            return await DbSet.AsNoTracking().Where(p => p.PartidaId == partidaId).Include(p => p.Jogador).ToListAsync();
        }
    }
}