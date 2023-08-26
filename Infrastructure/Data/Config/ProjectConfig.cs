using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class ProjectConfig : BaseEntityConfig<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .HasMaxLength(160)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(2000)
                .IsRequired();

            IMutableNavigation? timesheetsNavigation = builder.Metadata.FindNavigation(nameof(Project.Timesheets));
            timesheetsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
