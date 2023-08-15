using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class LeaveConfig : BaseEntityConfig<Leave>
    {
        public override void Configure(EntityTypeBuilder<Leave> builder)
        {
            base.Configure(builder);

            builder.Property(l => l.Remarks)
                .HasMaxLength(200);

            IMutableNavigation? leaveDaysNavigation =
                builder.Metadata.FindNavigation(nameof(Leave.LeaveDays));

            leaveDaysNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
