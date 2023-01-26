using ParkingHavan.Domain.Models.Common;
using System;

namespace ParkingHavan.Domain.Models
{
    public class EstacionamentoModel : BaseModel
    {
        public long? ClienteId { get; set; }
        public string Placa { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime? HorarioFinal { get; set; }
        public decimal ValorPagamento { get; set; }
    }
}
