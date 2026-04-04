using KS.Scheduler.Domain.Entities.Base;
using KS.Scheduler.Domain.Enums;
using System;

namespace KS.Scheduler.Domain.Entities
{
    public class Presenca : Entity
    {
        protected Presenca() { }

        public Presenca(Guid partidaId, Guid jogadorId, StatusPresenca statusInicial)
        {
            PartidaId = partidaId;
            JogadorId = jogadorId;
            Status = statusInicial;
        }

        public Guid PartidaId { get; private set; }
        public Guid JogadorId { get; private set; }
        public StatusPresenca Status { get; private set; }
        public DateTime? DataConfirmacao { get; private set; }
        public DateTime? DataPagamento { get; private set; }

        public virtual Partida Partida { get; private set; }
        public virtual Jogador Jogador { get; private set; }

        public void Confirmar()
        {
            if (Status == StatusPresenca.Recusado)
                throw new InvalidOperationException("Jogador recusou a partida.");

            if (Status == StatusPresenca.Pago)
                return;

            Status = StatusPresenca.Confirmado;
            DataConfirmacao = DateTime.UtcNow;
        }

        public void Recusar()
        {
            if (Status == StatusPresenca.Pago)
                throw new InvalidOperationException("Não é possível recusar após pagamento.");

            Status = StatusPresenca.Recusado;
            DataConfirmacao = DateTime.UtcNow;
        }

        public void RegistrarPagamento()
        {
            if (Status != StatusPresenca.Confirmado)
                throw new InvalidOperationException("Só é possível registrar pagamento para presença confirmada.");

            Status = StatusPresenca.Pago;
            DataPagamento = DateTime.UtcNow;
        }

        public void MoverParaPendente()
        {
            Status = StatusPresenca.Pendente;
        }
    }
}