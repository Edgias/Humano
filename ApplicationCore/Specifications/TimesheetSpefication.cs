using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.ApplicationCore.Specifications
{
    public class TimesheetSpecification : BaseSpecification<Timesheet>
    {
        public TimesheetSpecification(Guid timesheetId)
            : base(e => e.Id == timesheetId)
        {
            AddInclude(e => e.Employee);
        }
    }
}
