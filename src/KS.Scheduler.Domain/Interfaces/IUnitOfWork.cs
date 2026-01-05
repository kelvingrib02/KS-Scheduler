using System.Threading.Tasks;

namespace KS.Scheduler.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}