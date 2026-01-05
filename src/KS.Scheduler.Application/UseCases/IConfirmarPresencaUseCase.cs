using KS.Scheduler.Application.DTOs;
using System.Threading.Tasks;

namespace KS.Scheduler.Application.UseCases
{
    public interface IConfirmarPresencaUseCase
    {
        Task Execute(ConfirmarPresencaInput input);
    }
}