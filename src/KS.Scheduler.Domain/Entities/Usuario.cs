using KS.Scheduler.Domain.Entities.Base;
using KS.Scheduler.Domain.Enums;
using System.Collections.Generic;

namespace KS.Scheduler.Domain.Entities
{
    public class Usuario : Entity
    {
        protected Usuario() { }

        public Usuario(string nome, string email, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public void AtualizarTelefone(string novoTelefone)
        {
            Telefone = novoTelefone;
        }
    }
}
