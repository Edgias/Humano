namespace Edgias.Humano.ApplicationCore.Entities
{
    public class SalaryAdjustment : BaseEntity
    {
        public decimal Amount { get; private set; }

        public DateTime EffectiveDate { get; private set; }

        public Guid WorkExperienceId { get; private set; }

        public WorkExperience WorkExperience { get; private set; } = null!;

        public SalaryAdjustment(decimal amount, DateTime effectiveDate)
        {
            Amount = amount;
            EffectiveDate = effectiveDate;
        }
    }
}
