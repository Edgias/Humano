using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class WorkExperienceConfig : BaseEntityConfig<WorkExperience>
    {
        public override void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            base.Configure(builder);

            builder.Property(we => we.Salary)
                .HasColumnType("decimal(18,2)");

            IMutableNavigation? salaryAdjustmentsNavigation =
                builder.Metadata.FindNavigation(nameof(WorkExperience.SalaryAdjustments));
            salaryAdjustmentsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            IMutableNavigation? workExperienceBenefitsNavigation =
                builder.Metadata.FindNavigation(nameof(WorkExperience.WorkExperienceBenefits));
            workExperienceBenefitsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
