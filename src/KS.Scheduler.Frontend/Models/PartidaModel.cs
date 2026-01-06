using System;

namespace KS.Scheduler.Frontend.Models
{
    public class PartidaModel
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; } = string.Empty;
        public int TipoJogo { get; set; }
        public decimal ValorPorPessoa { get; set; }
        public int MaximoJogadores { get; set; }
    }
}