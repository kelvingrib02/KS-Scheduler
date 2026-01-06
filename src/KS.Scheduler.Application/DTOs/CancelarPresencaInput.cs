using System;

namespace KS.Scheduler.Application.DTOs
{
    public class CancelarPresencaInput
    {
        public Guid PartidaId { get; set; }
        public string TelefoneJogador { get; set; }
    }
}