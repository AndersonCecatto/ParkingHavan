using ParkingHavan.Data.Common;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Data.Repositories.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Repositories
{
    public class PeriodoVigenciaTipoPeriodoRepository : RepositoryBase<PeriodoVigenciaTipoPeriodo>, IPeriodoVigenciaTipoPeriodoRepository
    {
        public PeriodoVigenciaTipoPeriodoRepository(ParkingContext parkingContext) : base(parkingContext) { }
    }
}
