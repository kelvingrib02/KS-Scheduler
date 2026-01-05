using KS.Scheduler.Domain.Entities.Base;
using KS.Scheduler.Domain.Enums;
using System;

namespace KS.Scheduler.Domain.Entities
{
    public class Presenca : Entity
    {
        protected Presenca() { }

        public Presenca(Guid partidaId, Guid jogadorId)
        {
            PartidaId = partidaId;
            JogadorId = jogadorId;
            Status = StatusPresenca.Pendente;
            DataConfirmacao = null;
        }

        public Guid PartidaId { get; private set; }
        public Guid JogadorId { get; private set; }
        public StatusPresenca Status { get; private set; }
        public DateTime? DataConfirmacao { get; private set; }
        public virtual Partida Partida { get; private set; }
        public virtual Jogador Jogador { get; private set; }

        public void Confirmar()
        {
            Status = StatusPresenca.Confirmado;
            DataConfirmacao = DateTime.UtcNow;
        }

        public void Recusar()
        {
            Status = StatusPresenca.Recusado;
            DataConfirmacao = DateTime.UtcNow;
        }

        public void RegistrarPagamento()
        {
            Status = StatusPresenca.Pago;
            DataConfirmacao = DateTime.UtcNow;
        }
    }
}