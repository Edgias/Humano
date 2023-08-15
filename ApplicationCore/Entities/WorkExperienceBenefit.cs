namespace Edgias.Humano.ApplicationCore.Entities
{
    public class WorkExperienceBenefit : BaseEntity
    {
        public DateTime EffectiveDate { get; private set; }

        public string BenefitName { get; private set; } = default!;

        public decimal EmployeeDeduction { get; private set; }

        public decimal CompanyContribution { get; private set; }

        public Guid BenefitId { get; private set; }

        public Benefit Benefit { get; private set; } = default!;

        private WorkExperienceBenefit()
        {

        }

        public WorkExperienceBenefit(string benefitName, DateTime effectiveDate,
            decimal employeeDeduction, decimal companyContribution)
        {
            BenefitName = benefitName;
            EffectiveDate = effectiveDate;
            EmployeeDeduction = employeeDeduction;
            CompanyContribution = companyContribution;
        }

    }
}
