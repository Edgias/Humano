using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class LeaveCategoryConfig : BaseEntityConfig<LeaveCategory>
    {
        public override void Configure(EntityTypeBuilder<LeaveCategory> builder)
        {
            base.Configure(builder);

            builder.Property(lc => lc.Name)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
