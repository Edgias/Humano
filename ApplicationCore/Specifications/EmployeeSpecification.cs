using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.ApplicationCore.Specifications
{
    public class EmployeeSpecification : BaseSpecification<Employee>
    {
        public EmployeeSpecification(Guid employeeId)
            : base(e => e.Id == employeeId)
        {
            AddInclude(e => e.Manager);
        }
    }
}
