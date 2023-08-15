using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class WorkExperienceBenefitConfig : BaseEntityConfig<WorkExperienceBenefit>
    {
        public override void Configure(EntityTypeBuilder<WorkExperienceBenefit> builder)
        {
            base.Configure(builder);

            builder.Property(web => web.BenefitName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(web => web.EmployeeDeduction)
                .HasColumnType("decimal(18,2)");

            builder.Property(web => web.CompanyContribution)
                .HasColumnType("decimal(18,2)");

        }
    }
}
