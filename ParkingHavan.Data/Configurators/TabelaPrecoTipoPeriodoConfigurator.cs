using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingHavan.Data.Configurators.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Configurators
{
    public class TabelaPrecoTipoPeriodoConfigurator : BaseEntityConfigurator<TabelaPrecoTipoPeriodo>
    {
        protected override void InternalConfigure(EntityTypeBuilder<TabelaPrecoTipoPeriodo> builder)
        {
        }
    }
}
