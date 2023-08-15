using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class GradeBenefitConfig : BaseEntityConfig<GradeBenefit>
    {
        public override void Configure(EntityTypeBuilder<GradeBenefit> builder)
        {
            base.Configure(builder);

            builder.Property(gb => gb.BenefitName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(gb => gb.EmployeeDeduction)
                .HasColumnType("decimal(18,2)");

            builder.Property(gb => gb.CompanyContribution)
                .HasColumnType("decimal(18,2)");
        }
    }
}
