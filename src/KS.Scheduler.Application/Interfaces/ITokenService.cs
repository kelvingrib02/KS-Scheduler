using KS.Scheduler.Domain.Entities;

namespace KS.Scheduler.Application.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}