using KS.Scheduler.Domain.Entities.Base;
using KS.Scheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KS.Scheduler.Domain.Entities
{
    public class Partida : Entity
    {
        protected Partida() { }
        public Partida(DateTime dataHora, string local, int maximoJogadores, TipoJogo tipoJogo, decimal valorTotal, decimal? valorPorPessoa = null)
        {
            DataHora = dataHora;
            Local = local;
            MaximoJogadores = maximoJogadores;
            TipoJogo = tipoJogo;
            ValorTotal = valorTotal;
            ValorPorPessoa = valorPorPessoa ?? 0;
            Presencas = new List<Presenca>();
        }

        public DateTime DataHora { get; private set; }
        public string Local { get; private set; }
        public int MaximoJogadores { get; private set; }
        public TipoJogo TipoJogo { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorPorPessoa { get; private set; }
        public virtual ICollection<Presenca> Presencas { get; private set; }

        public void AdicionarJogador(Jogador jogador)
        {
            if (Presencas.Any(p => p.JogadorId == jogador.Id))
                return;

            var novaPresenca = new Presenca(this.Id, jogador.Id);
            Presencas.Add(novaPresenca);
        }

        public void CalcularValorPorPessoa()
        {
            var totalConfirmados = Presencas.Count(x => x.Status == StatusPresenca.Confirmado || x.Status == StatusPresenca.Pago);
            if (totalConfirmados > 0)
            {
                ValorPorPessoa = ValorTotal / totalConfirmados;
            }
        }
    }
}