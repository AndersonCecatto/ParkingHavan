using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingHavan.Data.Configurators.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Configurators
{
    public class ClienteConfigurator : BaseEntityConfigurator<Cliente>
    {
        protected override void InternalConfigure(EntityTypeBuilder<Cliente> builder)
        {
        }
    }
}
