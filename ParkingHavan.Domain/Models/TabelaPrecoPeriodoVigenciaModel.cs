using ParkingHavan.Domain.Models.Common;
using System;

namespace ParkingHavan.Domain.Models
{
    public class TabelaPrecoPeriodoVigenciaModel : BaseModel
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
