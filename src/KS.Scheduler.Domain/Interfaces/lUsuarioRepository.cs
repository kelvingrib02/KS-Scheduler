using KS.Scheduler.Domain.Entities;
using System.Threading.Tasks;

namespace KS.Scheduler.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterPorTelefone(string telefone);
    }
}