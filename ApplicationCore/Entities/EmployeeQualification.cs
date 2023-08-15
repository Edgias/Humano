namespace Edgias.Humano.ApplicationCore.Entities
{
    public class EmployeeQualification : BaseEntity
    {
        public string School { get; private set; } = string.Empty;

        public QualificationLevel Level { get; private set; }

        public string FieldOfStudy { get; private set; } = string.Empty;

        public string Grade { get; private set; } = string.Empty;

        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public Guid EmployeeId { get; private set; }

        public Employee Employee { get; private set; } = null!;

        private EmployeeQualification()
        {
            
        }

        public EmployeeQualification(QualificationLevel level, string school, string grade,
            string fieldOfStudy, DateTime startDate, DateTime? endDate)
        {
            Level = level;
            School = school;
            Grade = grade;
            FieldOfStudy = fieldOfStudy;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
