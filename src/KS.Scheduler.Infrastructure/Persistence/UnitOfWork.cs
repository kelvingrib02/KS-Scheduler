using KS.Scheduler.Domain.Interfaces;
using KS.Scheduler.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace KS.Scheduler.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KSSchedulerDbContext _context;

        private IJogadorRepository _jogadores;
        private IPartidaRepository _partidas;
        private IPresencaRepository _presencas;
        private IUsuarioRepository _usuario;
        public UnitOfWork(KSSchedulerDbContext context)
        {
            _context = context;
        }
        public IJogadorRepository Jogadores
        {
            get
            {
                return _jogadores ??= new JogadorRepository(_context);
            }
        }
        public IPartidaRepository Partidas
        {
            get { return _partidas ??= new PartidaRepository(_context); }
        }
        public IPresencaRepository Presencas
        {
            get { return _presencas ??= new PresencaRepository(_context); }
        }
        public IUsuarioRepository Usuario
        {
            get { return _usuario ??= new UsuarioRepository(_context); }
        }
        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}