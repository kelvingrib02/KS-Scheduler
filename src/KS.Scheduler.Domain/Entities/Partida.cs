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

        public Partida(
            DateTime dataHora,
            string local,
            int maximoJogadores,
            TipoJogo tipoJogo,
            decimal valorTotal,
            decimal? valorPorPessoa = null)
        {
            if (maximoJogadores <= 0)
                throw new ArgumentException("O máximo de jogadores deve ser maior que zero.");

            if (valorTotal < 0)
                throw new ArgumentException("O valor total não pode ser negativo.");

            DataHora = dataHora;
            Local = local;
            MaximoJogadores = maximoJogadores;
            TipoJogo = tipoJogo;
            ValorTotal = valorTotal;
            ValorPorPessoa = valorPorPessoa;
            Presencas = new List<Presenca>();
        }

        public DateTime DataHora { get; private set; }
        public string Local { get; private set; }
        public int MaximoJogadores { get; private set; }
        public TipoJogo TipoJogo { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal? ValorPorPessoa { get; private set; }

        public virtual ICollection<Presenca> Presencas { get; private set; }

        public int TotalConfirmados =>
            Presencas.Count(p =>
                p.Status == StatusPresenca.Confirmado ||
                p.Status == StatusPresenca.Pago);

        public bool PossuiVaga => TotalConfirmados < MaximoJogadores;

        public void AdicionarJogador(Guid jogadorId)
        {
            if (Presencas.Any(p => p.JogadorId == jogadorId))
                throw new InvalidOperationException("Jogador já está na partida.");

            var statusInicial = PossuiVaga
                ? StatusPresenca.Pendente
                : StatusPresenca.ListaEspera;

            var presenca = new Presenca(Id, jogadorId, statusInicial);
            Presencas.Add(presenca);
        }

        public void RemoverJogador(Guid jogadorId)
        {
            var presenca = Presencas.FirstOrDefault(p => p.JogadorId == jogadorId);

            if (presenca == null)
                return;

            var liberouVaga = presenca.Status == StatusPresenca.Confirmado ||
                              presenca.Status == StatusPresenca.Pago;

            Presencas.Remove(presenca);

            if (liberouVaga)
                PromoverPrimeiroDaListaEspera();
        }

        public void CalcularValorPorPessoa()
        {
            var totalConfirmados = TotalConfirmados;

            if (totalConfirmados <= 0)
            {
                ValorPorPessoa = null;
                return;
            }

            ValorPorPessoa = ValorTotal / totalConfirmados;
        }

        public void AtualizarLocal(string local)
        {
            Local = local;
        }

        public void AtualizarData(DateTime dataHora)
        {
            DataHora = dataHora;
        }

        private void PromoverPrimeiroDaListaEspera()
        {
            var primeiroDaEspera = Presencas.Where(p => p.Status == StatusPresenca.ListaEspera).OrderBy(p => p.DataCriacao).FirstOrDefault();

            if (primeiroDaEspera != null && PossuiVaga)
                primeiroDaEspera.MoverParaPendente();
        }
    }
}