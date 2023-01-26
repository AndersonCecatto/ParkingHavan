using ParkingHavan.Data.Common;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Data.Repositories.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Repositories
{
    public class TabelaPrecoTipoPeriodoRepository : RepositoryBase<TabelaPrecoTipoPeriodo>, ITabelaPrecoTipoPeriodoRepository
    {
        public TabelaPrecoTipoPeriodoRepository(ParkingContext parkingContext) : base(parkingContext) { }
    }
}
