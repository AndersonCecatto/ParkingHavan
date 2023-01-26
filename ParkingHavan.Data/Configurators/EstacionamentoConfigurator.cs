using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingHavan.Data.Configurators.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Configurators
{
    public class EstacionamentoConfigurator : BaseEntityConfigurator<Estacionamento>
    {
        protected override void InternalConfigure(EntityTypeBuilder<Estacionamento> builder)
        {
        }
    }
}
