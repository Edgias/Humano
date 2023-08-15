using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Benefit : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = default!;

        public decimal EmployeeDeduction { get; private set; }

        public decimal CompanyContribution { get; private set; }

        public Benefit(string name, decimal employeeDeduction, decimal companyContribution)
        {
            Name = name;
            EmployeeDeduction = employeeDeduction;
            CompanyContribution = companyContribution;
        }
    }
}
