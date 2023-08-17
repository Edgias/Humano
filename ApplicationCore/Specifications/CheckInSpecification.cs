using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.ApplicationCore.Specifications
{
    public class CheckInSpecification : BaseSpecification<CheckIn>
    {
        public CheckInSpecification()
            : base(criteria: default!)
        {
            AddInclude(c => c.Employee);
        }

        public CheckInSpecification(Guid checkId)
            : base(e => e.Id == checkId)
        {
            AddInclude(e => e.Employee);
        }
    }
}
