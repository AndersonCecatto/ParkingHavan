using ParkingHavan.Domain.Entities.Common;
using System;

namespace ParkingHavan.Domain.Entities
{
    public class TabelaPrecoPeriodoVigencia : EntityBase
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
