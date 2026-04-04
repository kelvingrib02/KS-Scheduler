using System;

namespace KS.Scheduler.Application.DTOs
{
    public class ConfirmarPresencaInput
    {
        public Guid PartidaId { get; set; }
        public string NomeJogador { get; set; } = string.Empty;
        public Guid JogadorId { get; set; }
        public string Posicao { get; set; } = "Linha";
    }
}