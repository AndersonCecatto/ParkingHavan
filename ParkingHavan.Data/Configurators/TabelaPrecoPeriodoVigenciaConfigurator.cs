using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingHavan.Data.Configurators.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Configurators
{
    public class TabelaPrecoPeriodoVigenciaConfigurator : BaseEntityConfigurator<TabelaPrecoPeriodoVigencia>
    {
        protected override void InternalConfigure(EntityTypeBuilder<TabelaPrecoPeriodoVigencia> builder)
        {
        }
    }
}
