using System;
using System.Collections.Generic;

namespace KS.Scheduler.Frontend.Models
{
    public class PartidaViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; } = string.Empty;
        public decimal ValorPorPessoa { get; set; }
        public int MaximoJogadores { get; set; }
        public List<PresencaViewModel> Presencas { get; set; } = new();
    }

    public class PresencaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Posicao { get; set; } = string.Empty;
        public bool Confirmado { get; set; }
    }
}