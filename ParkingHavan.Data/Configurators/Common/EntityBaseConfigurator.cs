using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingHavan.Domain.Entities.Common;

namespace ParkingHavan.Data.Configurators.Common
{
    public abstract class BaseEntityConfigurator<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).IsRequired();

            InternalConfigure(builder);
        }

        protected abstract void InternalConfigure(EntityTypeBuilder<TEntity> builder);
    }
}
