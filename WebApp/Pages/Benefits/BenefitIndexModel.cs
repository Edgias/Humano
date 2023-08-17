namespace Edgias.Humano.WebApp.Pages.Benefits
{
    public class BenefitIndexModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public decimal EmployeeDeduction { get; set; }

        public decimal CompanyContribution { get; set; }
    }
}
