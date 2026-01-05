using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KS.Scheduler.Infrastructure.Repositories
{
    public class PartidaRepository : Repository<Partida>, IPartidaRepository
    {
        public PartidaRepository(KSSchedulerDbContext context) : base(context)
        {
        }
        public async Task<Partida> ObterPorIdComPresencas(Guid id)
        {
            return await DbSet.Include(p => p.Presencas).ThenInclude(pr => pr.Jogador).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}