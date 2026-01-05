using KS.Scheduler.Domain.Entities;
using System.Threading.Tasks;

namespace KS.Scheduler.Domain.Interfaces
{
    public interface IJogadorRepository : IRepository<Jogador>
    {
        Task<Jogador> ObterPorTelefone(string telefone);
    }
}