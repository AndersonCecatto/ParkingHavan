using ParkingHavan.Data.Common;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Data.Repositories.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ParkingContext parkingContext) : base(parkingContext) { }
    }
}
