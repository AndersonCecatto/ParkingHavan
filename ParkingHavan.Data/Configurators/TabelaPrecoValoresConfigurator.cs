﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingHavan.Data.Configurators.Common;
using ParkingHavan.Domain.Entities;

namespace ParkingHavan.Data.Configurators
{
    public class TabelaPrecoValoresConfigurator : BaseEntityConfigurator<TabelaPrecoValores>
    {
        protected override void InternalConfigure(EntityTypeBuilder<TabelaPrecoValores> builder)
        {
        }
    }
}
