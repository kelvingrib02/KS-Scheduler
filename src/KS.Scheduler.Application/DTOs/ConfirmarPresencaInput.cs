using System;

namespace KS.Scheduler.Application.DTOs
{
    public class ConfirmarPresencaInput
    {
        public Guid PartidaId { get; set; }
        public Guid JogadorId { get; set; }
    }
}
