using System;

namespace KS.Scheduler.Application.DTOs
{
    public class ConfirmarPresencaInput
    {
        public Guid PartidaId { get; set; }
        public string NomeJogador { get; set; } = string.Empty;
        public string TelefoneJogador { get; set; } = string.Empty;
        public string Posicao { get; set; } = "Linha";
    }
}