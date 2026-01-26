namespace KS.Scheduler.Domain.Interfaces
{
    public interface IAuthService
    {
        string GerarHash(string senha);
        bool ValidarSenha(string senha, string hash);
        string GerarToken(Guid usuarioId, string email, string nome);
    }
}