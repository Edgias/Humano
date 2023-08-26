using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.ApplicationCore.Specifications
{
    public class ProjectSpecification : BaseSpecification<Project>
    {
        public ProjectSpecification()
            : base(criteria: default!)
        {
            AddInclude(p => p.Timesheets);
            AddInclude($"{nameof(Project.Timesheets)}.{nameof(Timesheet.Employee)}");
        }

        public ProjectSpecification(Guid id)
            : base(p => p.Id == id)
        {
            AddInclude(p => p.Timesheets);
            AddInclude($"{nameof(Project.Timesheets)}.{nameof(Timesheet.Employee)}");
        }
    }
}
