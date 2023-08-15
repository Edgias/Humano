using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class EmployeeQualificationConfig : BaseEntityConfig<EmployeeQualification>
    {
        public override void Configure(EntityTypeBuilder<EmployeeQualification> builder)
        {
            base.Configure(builder);

            builder.Property(eq => eq.School)
                .HasMaxLength(160)
                .IsRequired();

            builder.Property(eq => eq.FieldOfStudy)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(eq => eq.Grade)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
