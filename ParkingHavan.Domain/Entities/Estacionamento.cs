using ParkingHavan.Domain.Entities.Common;
using System;

namespace ParkingHavan.Domain.Entities
{
    public class Estacionamento : EntityBase
    {
        public long? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Placa { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime? HorarioFinal { get; set; }
        public decimal ValorPagamento { get; set; }
    }
}
