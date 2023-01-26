using ParkingHavan.Domain.Models.Common;
using System;

namespace ParkingHavan.Domain.Models
{
    public class TabelaPrecoTipoPeriodoModel : BaseModel
    {
        public string Descricao { get; set; }
        public DayOfWeek Dia { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
    }
}
