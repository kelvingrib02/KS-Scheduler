using KS.Scheduler.Domain.Entities.Base;

namespace KS.Scheduler.Domain.Entities
{
    public class Usuario : Entity
    {
        protected Usuario() { }

        public Usuario(string nome, string email, string telefone, string senhaHash)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            SenhaHash = senhaHash;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string SenhaHash { get; private set; }

        public void AtualizarTelefone(string novoTelefone)
        {
            Telefone = novoTelefone;
        }
        public void AtualizarEmail(string novoEmail)
        {
            Email = novoEmail;
        }

        public void AtualizarSenha(string novaSenhaHash)
        {
            SenhaHash = novaSenhaHash;
        }
    }
}