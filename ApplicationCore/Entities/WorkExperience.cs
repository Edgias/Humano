namespace Edgias.Humano.ApplicationCore.Entities
{
    public class WorkExperience : BaseEntity
    {
        public decimal Salary { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public Guid GradeId { get; private set; }

        public Grade Grade { get; private set; } = default!;

        public Guid JobTitleId { get; private set; }

        public JobTitle JobTitle { get; private set; } = default!;

        public Guid EmployeeId { get; private set; }

        public Employee Employee { get; private set; } = default!;

        private readonly List<SalaryAdjustment> _salaryAdjustments = new();
        public IReadOnlyCollection<SalaryAdjustment> SalaryAdjustments => _salaryAdjustments.AsReadOnly();

        private readonly List<WorkExperienceBenefit> _workExperienceBenefits = new();
        public IReadOnlyCollection<WorkExperienceBenefit> WorkExperienceBenefits => _workExperienceBenefits.AsReadOnly();

        private WorkExperience()
        {
            
        }

        public WorkExperience(decimal salary, DateTime startDate, DateTime? endDate, Guid jobTitleId,
            Guid employeeId, Guid gradeId)
        {
            Salary = salary;
            StartDate = startDate;
            EndDate = endDate;
            JobTitleId = jobTitleId;
            EmployeeId = employeeId;
            GradeId = gradeId;
        }

        public void AddBenefit(WorkExperienceBenefit workExperienceBenefit)
        {
            _workExperienceBenefits.Add(workExperienceBenefit);
        }

        public void AddBenefits(IEnumerable<WorkExperienceBenefit> workExperienceBenefits)
        {
            _workExperienceBenefits.AddRange(workExperienceBenefits);
        }

        public void AdjustSalary(SalaryAdjustment salaryAdjustment) 
        { 
            _salaryAdjustments.Add(salaryAdjustment);
        }

        public decimal GetSalary()
        {
            decimal salary = decimal.Zero;

            if (_salaryAdjustments.Any()) 
            {
                var salaries = _salaryAdjustments.OrderByDescending(s => s.EffectiveDate);
                salary = salaries.First().Amount;
            }
            else
            {
                salary = Salary;
            }

            return salary;
        }
    }
}
