using ParkingHavan.Domain.Entities.Common;

namespace ParkingHavan.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string PlacaCarro { get; set; }
    }
}
