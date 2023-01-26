using ParkingHavan.Domain.Models.Common;

namespace ParkingHavan.Domain.Models
{
    public class TabelaPrecoValoresModel : BaseModel
    {
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public decimal Valor { get; set; }
    }
}
