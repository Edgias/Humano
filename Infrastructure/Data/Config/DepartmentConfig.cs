using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class DepartmentConfig : BaseEntityConfig<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);

            builder.Property(d => d.Name)
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(d => d.Email)
                .HasMaxLength(100);

        }
    }
}
