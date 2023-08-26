using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class RateConfig : BaseEntityConfig<Rate>
    {
        public override void Configure(EntityTypeBuilder<Rate> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.Name)
                .HasMaxLength(160)
                .IsRequired();

            builder.Property(r => r.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
