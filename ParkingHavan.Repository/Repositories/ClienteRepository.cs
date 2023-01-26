using ParkingHavan.Domain.Entities;
using ParkingHavan.Repository.Interfaces.Repositories;
using ParkingHavan.Repository.Repositories.Common;

namespace ParkingHavan.Repository.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ParkingContext parkingContext) : base(parkingContext) { }
    }
}
