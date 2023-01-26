using ParkingHavan.Domain.Models.Common;

namespace ParkingHavan.Domain.Models
{
    public class ClienteModel : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string PlacaCarro { get; set; }
    }
}
