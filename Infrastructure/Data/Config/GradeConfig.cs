using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class GradeConfig : BaseEntityConfig<Grade>
    {
        public override void Configure(EntityTypeBuilder<Grade> builder)
        {
            base.Configure(builder);

            builder.Property(g => g.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(g => g.MinimumSalary)
                .HasColumnType("decimal(18,2)");

            builder.Property(g => g.MaximumSalary)
                .HasColumnType("decimal(18,2)");

            IMutableNavigation? benefitsNavigation =
                builder.Metadata.FindNavigation(nameof(Grade.Benefits));

            benefitsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
