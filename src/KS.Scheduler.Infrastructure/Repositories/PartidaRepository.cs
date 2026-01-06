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
    public class PartidaRepository : Repository<Partida>, IPartidaRepository
    {
        public PartidaRepository(KSSchedulerDbContext context) : base(context)
        {
        }

        public async Task<Partida?> ObterPartidaComPresencas(Guid id)
        {
            return await DbSet.Include(p => p.Presencas).ThenInclude(presenca => presenca.Jogador).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Partida>> ObterPartidasPorData(DateTime dataInicio, DateTime dataFim)
        {
            return await DbSet.AsNoTracking().Where(p => p.DataHora >= dataInicio && p.DataHora <= dataFim).OrderBy(p => p.DataHora).ToListAsync();
        }

        public async Task CriarAsync(Partida partida)
        {
            await DbSet.AddAsync(partida);
        }
        public async Task<Partida?> ObterPorIdCompletoAsync(Guid id)
        {
            return await DbSet.Include(p => p.Presencas).ThenInclude(pr => pr.Jogador).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}