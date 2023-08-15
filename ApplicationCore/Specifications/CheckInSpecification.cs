using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.ApplicationCore.Specifications
{
    public class CheckInSpecification : BaseSpecification<CheckIn>
    {
        public CheckInSpecification(Guid checkId)
            : base(e => e.Id == checkId)
        {
            AddInclude(e => e.Employee);
        }
    }
}
