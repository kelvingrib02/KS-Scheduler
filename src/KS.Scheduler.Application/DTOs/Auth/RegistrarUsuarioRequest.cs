namespace KS.Scheduler.Application.DTOs.Auth
{
    public class RegistrarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
    }
}