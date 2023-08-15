using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class EmployeeConfig : BaseEntityConfig<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(60);

            builder.Property(e => e.NationalId)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Mobile)
                .HasMaxLength(30);

            builder.OwnsOne(e => e.ResidentialAddress, residentialAddress =>
            {
                residentialAddress.WithOwner();

                residentialAddress.Property(a => a.Street)
                    .HasMaxLength(180);

                residentialAddress.Property(a => a.State)
                    .HasMaxLength(60);

                residentialAddress.Property(a => a.Country)
                    .HasMaxLength(90);

                residentialAddress.Property(a => a.City)
                    .HasMaxLength(100);
            });

           IMutableNavigation? checkInsNavigation =
                builder.Metadata.FindNavigation(nameof(Employee.CheckIns));

            checkInsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            IMutableNavigation? qualificationsNavigation = 
                builder.Metadata.FindNavigation(nameof(Employee.EmployeeQualifications));
            qualificationsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            IMutableNavigation? leavesNavigation = 
                builder.Metadata.FindNavigation(nameof(Employee.Leaves));
            leavesNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            IMutableNavigation? timesheetsNavigation =
                builder.Metadata.FindNavigation(nameof(Employee.Timesheets));
            timesheetsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            IMutableNavigation? experiencesNavigation =
                builder.Metadata.FindNavigation(nameof(Employee.WorkExperiences));
            experiencesNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
