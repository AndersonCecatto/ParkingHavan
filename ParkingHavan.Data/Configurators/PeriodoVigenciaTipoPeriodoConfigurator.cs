using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingHavan.Data.Configurators.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Configurators
{
    public class PeriodoVigenciaTipoPeriodoConfigurator : BaseEntityConfigurator<PeriodoVigenciaTipoPeriodo>
    {
        protected override void InternalConfigure(EntityTypeBuilder<PeriodoVigenciaTipoPeriodo> builder)
        {
        }
    }
}
