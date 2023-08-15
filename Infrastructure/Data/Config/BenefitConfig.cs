using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class BenefitConfig : BaseEntityConfig<Benefit>
    {
        public override void Configure(EntityTypeBuilder<Benefit> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(b => b.EmployeeDeduction)
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.CompanyContribution)
                .HasColumnType("decimal(18,2)");
        }
    }
}
