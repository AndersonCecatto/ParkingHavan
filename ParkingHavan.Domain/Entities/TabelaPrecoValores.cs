using ParkingHavan.Domain.Entities.Common;

namespace ParkingHavan.Domain.Entities
{
    public class TabelaPrecoValores : EntityBase
    {
        public int Minuto { get; set; }
        public decimal Valor { get; set; }
    }
}
