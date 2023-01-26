using ParkingHavan.Data.Common;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Data.Repositories.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Repositories
{
    public class TabelaPrecoPeriodoVigenciaRepository : RepositoryBase<TabelaPrecoPeriodoVigencia>, ITabelaPrecoPeriodoVigenciaRepository
    {
        public TabelaPrecoPeriodoVigenciaRepository(ParkingContext parkingContext) : base(parkingContext) { }

    }
}
