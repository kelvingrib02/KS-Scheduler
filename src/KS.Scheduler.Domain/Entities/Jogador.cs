using KS.Scheduler.Domain.Entities;
using KS.Scheduler.Domain.Entities.Base;
using KS.Scheduler.Domain.Enums;

public class Jogador : Entity
{
    protected Jogador() { }

    public Jogador(Guid usuarioId, string posicao, NivelHabilidade nivelHabilidade)
    {
        UsuarioId = usuarioId;
        Posicao = posicao;
        NivelHabilidade = nivelHabilidade;
        Presencas = new List<Presenca>();
    }

    public Guid UsuarioId { get; private set; }
    public string Posicao { get; private set; }
    public NivelHabilidade NivelHabilidade { get; private set; }

    public virtual Usuario Usuario { get; private set; }
    public virtual ICollection<Presenca> Presencas { get; private set; }

    public void AtualizarHabilidade(NivelHabilidade novoNivel)
    {
        NivelHabilidade = novoNivel;
    }
}