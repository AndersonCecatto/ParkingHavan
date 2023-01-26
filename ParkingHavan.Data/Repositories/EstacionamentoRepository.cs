using ParkingHavan.Data.Common;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Data.Repositories.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Repositories
{
    public class EstacionamentoRepository : RepositoryBase<Estacionamento>, IEstacionamentoRepository
    {
        public EstacionamentoRepository(ParkingContext parkingContext) : base(parkingContext) { }
    }
}
