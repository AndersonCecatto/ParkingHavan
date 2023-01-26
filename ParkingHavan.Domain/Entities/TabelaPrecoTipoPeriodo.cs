using ParkingHavan.Domain.Entities.Common;
using System;

namespace ParkingHavan.Domain.Entities
{
    public class TabelaPrecoTipoPeriodo : EntityBase
    {
        public string Descricao { get; set; }
        public DayOfWeek Dia { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
    }
}
