using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KS.Scheduler.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(KSSchedulerDbContext context) : base(context)
        {
        }

        public async Task<Usuario> ObterPorTelefone(string telefone)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(j => j.Telefone == telefone);
        }
    }
}