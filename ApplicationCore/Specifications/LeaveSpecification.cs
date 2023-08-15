using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.ApplicationCore.Specifications
{
    public class LeaveSpecification : BaseSpecification<Leave>
    {
        public LeaveSpecification()
            : base(criteria: default!)
        {
            AddInclude(l => l.LeaveCategory);
            AddInclude(l => l.Employee);
            AddInclude(l => l.LeaveDays);
        }

        public LeaveSpecification(Guid employeeId, DateTime startDate, DateTime endDate)
            : base(l => l.EmployeeId == employeeId && l.StartDate >= startDate && l.EndDate <= endDate)
        {
            AddInclude(l => l.LeaveCategory);
            AddInclude(l => l.LeaveDays);
            ApplyOrderBy(l => l.StartDate);
        }

        public LeaveSpecification(Guid employeeId, Guid categoryId, DateTime startDate, DateTime endDate)
            : base(l => l.EmployeeId == employeeId && l.LeaveCategoryId == categoryId 
            && l.StartDate >= startDate && l.EndDate <= endDate)
        {
            AddInclude(l => l.LeaveDays);
            ApplyOrderBy(l => l.StartDate);
        }
    }
}
