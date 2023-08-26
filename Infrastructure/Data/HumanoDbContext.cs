using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using Edgias.Humano.ApplicationCore.Entities;
using Edgias.Humano.ApplicationCore.Interfaces;
using Edgias.Humano.Infrastructure.Identity;
using System.Data.Common;

namespace Edgias.Humano.Infrastructure.Data
{
    public class HumanoDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public HumanoDbContext(DbContextOptions<HumanoDbContext> options,
            IAuthenticatedUserService authenticatedUserService)
            : base(options)
        {
            _authenticatedUserService = authenticatedUserService;
        }

        public DbSet<Benefit> Benefits { get; set; }

        public DbSet<CalendarSetting> CalendarSettings { get; set; }

        public DbSet<CheckIn> CheckIns { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<GradeBenefit> GradeBenefits { get; set; }

        public DbSet<JobTitle> JobTitles { get; set; }

        public DbSet<Leave> Leaves { get; set; }

        public DbSet<LeaveCategory> LeaveCategories { get; set; }

        public DbSet<LeaveDay> LeaveDays { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<SalaryAdjustment> SalaryAdjustments { get; set; }

        public DbSet<Salutation> Salutations { get; set; }

        public DbSet<Timesheet> Timesheets { get; set; }

        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<WorkExperience> WorkExperience { get; set; }

        public DbSet<WorkExperienceBenefit> WorkExperienceBenefits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<ApplicationUser>()
                .Property(au => au.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(au => au.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(au => au.CreatedBy)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(au => au.LastModifiedBy)
                .HasMaxLength(50);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Set audit fields for entities inheriting from BaseEntity
            foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.SetCreatedBy(await _authenticatedUserService.GetUserId());
                        break;

                    case EntityState.Modified:
                        entry.Entity.SetLastModifiedBy(await _authenticatedUserService.GetUserId());
                        entry.Entity.SetLastModifiedDate();
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            //if (_mediator == null)
            //{
            //    return result;
            //}

            // dispatch events only if save was successful
            BaseEntity[] entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (BaseEntity entity in entitiesWithEvents)
            {
                BaseDomainEvent[] events = entity.Events.ToArray();

                entity.Events.Clear();

                //foreach (var domainEvent in events)
                //{
                //    await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
                //}
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
