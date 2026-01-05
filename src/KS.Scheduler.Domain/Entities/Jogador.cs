using KS.Scheduler.Domain.Entities.Base;
using KS.Scheduler.Domain.Enums;
using System.Collections.Generic;

namespace KS.Scheduler.Domain.Entities
{
    public class Jogador : Entity
    {
        protected Jogador() { }
        public Jogador(string nome, string telefone, string posicao, NivelHabilidade nivelHabilidade)
        {
            Nome = nome;
            Telefone = telefone;
            Posicao = posicao;
            NivelHabilidade = nivelHabilidade;
            Ativo = true;
        }

        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Posicao { get; private set; }
        public NivelHabilidade NivelHabilidade { get; private set; }
        public bool Ativo { get; private set; }
        public virtual ICollection<Presenca> Presencas { get; private set; }
        public void AtualizarTelefone(string novoTelefone)
        {
            Telefone = novoTelefone;
        }

        public void AtualizarNivel(NivelHabilidade novoNivel)
        {
            NivelHabilidade = novoNivel;
        }
    }
}
