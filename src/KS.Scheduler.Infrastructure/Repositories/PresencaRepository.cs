using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KS.Scheduler.Infrastructure.Repositories
{
    public class PresencaRepository : Repository<Presenca>, IPresencaRepository
    {
        public PresencaRepository(KSSchedulerDbContext context) : base(context)
        {
        }

        public async Task<Presenca> ObterPorPartidaEJogador(Guid partidaId, Guid jogadorId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(p => p.PartidaId == partidaId && p.JogadorId == jogadorId);
        }
    }
}
