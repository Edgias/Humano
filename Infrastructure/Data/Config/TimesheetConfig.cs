using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class TimesheetConfig : BaseEntityConfig<Timesheet>
    {
        public override void Configure(EntityTypeBuilder<Timesheet> builder)
        {
            base.Configure(builder);

            builder.Property(ts => ts.Description)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
