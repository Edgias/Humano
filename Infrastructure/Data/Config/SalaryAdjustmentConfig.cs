using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class SalaryAdjustmentConfig : BaseEntityConfig<SalaryAdjustment>
    {
        public override void Configure(EntityTypeBuilder<SalaryAdjustment> builder)
        {
            base.Configure(builder);

            builder.Property(sa => sa.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
