using ParkingHavan.Data.Common;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Data.Repositories.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Repositories
{
    public class TabelaPrecoValoresRepository : RepositoryBase<TabelaPrecoValores>, ITabelaPrecoValoresRepository
    {
        public TabelaPrecoValoresRepository(ParkingContext parkingContext) : base(parkingContext) { }
    }
}
