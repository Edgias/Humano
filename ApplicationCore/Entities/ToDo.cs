using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class ToDo : BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; } = default!;

        public bool IsComplete { get; private set; }

        public Guid? RelatedEntityId { get; private set; }

        public string? RelatedEntity { get; private set; } 

        public Guid EmployeeId { get; private set; }

        public Employee Employee { get; private set; } = default!;

        public ToDo(string title, Guid employeeId, Guid? relatedEntityId, string? relatedEntity)
        {
            Title = title;
            EmployeeId = employeeId;
            RelatedEntityId = relatedEntityId;
            RelatedEntity = relatedEntity;

        }

        public void Complete()
        {
            IsComplete = true;
        }
    }
}
