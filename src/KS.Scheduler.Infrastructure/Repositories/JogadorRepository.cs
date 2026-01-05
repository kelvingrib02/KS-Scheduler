using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KS.Scheduler.Infrastructure.Repositories
{
    public class JogadorRepository : Repository<Jogador>, IJogadorRepository
    {
        public JogadorRepository(KSSchedulerDbContext context) : base(context)
        {
        }

        public async Task<Jogador> ObterPorTelefone(string telefone)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(j => j.Telefone == telefone);
        }
    }
}