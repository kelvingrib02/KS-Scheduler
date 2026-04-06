using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KS.Scheduler.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(KSSchedulerDbContext context) : base(context)
        {
        }

        public async Task<Usuario> ObterPorIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await DbSet.AddAsync(usuario);
        }
    }
}