using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class CheckInConfig : BaseEntityConfig<CheckIn>
    {
        public override void Configure(EntityTypeBuilder<CheckIn> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.TimeIn)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.TimeOut)
                .HasMaxLength(30);
        }
    }
}
