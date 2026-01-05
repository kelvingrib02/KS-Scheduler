using System.Threading.Tasks;

namespace KS.Scheduler.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IJogadorRepository Jogadores { get; }
        IPartidaRepository Partidas { get; }
        IPresencaRepository Presencas { get; }
        Task<bool> Commit();
    }
}