using KS.Scheduler.Domain.Enums;
using System;

namespace KS.Scheduler.Application.DTOs
{
    public class CriarPartidaInput
    {
        public DateTime DataHora { get; set; }
        public string Local { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public decimal? ValorPorPessoa { get; set; }
        public int MaximoJogadores { get; set; }
        public TipoJogo TipoJogo { get; set; }
    }
}