using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class LeaveCategory : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }

        public int Allocation { get; private set; }

        public LeaveCategory(string name, int allocation)
        {
            Name = name;
            Allocation = allocation;
        }
    }
}
