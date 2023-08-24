using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.ApplicationCore.Specifications
{
    public class EmployeeDetailsSpecification : BaseSpecification<Employee>
    {
        public EmployeeDetailsSpecification()
            : base(criteria: default!)
        {
            AddInclude(e => e.Department);
            AddInclude(e => e.Salutation);
        }

        public EmployeeDetailsSpecification(Guid employeeId)
            : base(e => e.Id == employeeId)
        {
            AddInclude(e => e.Manager);
            AddInclude(e => e.Department);
            AddInclude(e => e.Salutation);
            AddInclude(e => e.CheckIns);
            AddInclude(e => e.DirectReports);
            AddInclude(e => e.EmployeeQualifications);
            AddInclude(e => e.Leaves);
            AddInclude($"{nameof(Employee.Leaves)}.{nameof(Leave.LeaveCategory)}");
            AddInclude(e => e.Timesheets);
            AddInclude(e => e.WorkExperiences);
            AddInclude($"{nameof(Employee.WorkExperiences)}.{nameof(WorkExperience.JobTitle)}");
            AddInclude($"{nameof(Employee.WorkExperiences)}.{nameof(WorkExperience.Grade)}");
            AddInclude($"{nameof(Employee.WorkExperiences)}.{nameof(WorkExperience.WorkExperienceBenefits)}");
        }

    }
}
