namespace Edgias.Humano.ApplicationCore.Entities
{
    public class GradeBenefit : BaseEntity
    {
        public string BenefitName { get; private set; } = default!;

        public decimal EmployeeDeduction { get; private set; }

        public decimal CompanyContribution { get; private set; }

        public Guid BenefitId { get; private set; }

        public Benefit Benefit { get; private set; } = default!;

        public GradeBenefit(string benefitName, decimal employeeDeduction, decimal companyContribution)
        {
            BenefitName = benefitName;
            EmployeeDeduction = employeeDeduction;
            CompanyContribution = companyContribution;
        }
    }
}
