namespace Edgias.Humano.ApplicationCore.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public bool IsActive { get; private set; } = true;

        public bool IsSoftDeleted { get; private set; }

        public string CreatedBy { get; private set; } = string.Empty;

        public string LastModifiedBy { get; private set; } = string.Empty;

        public DateTimeOffset CreatedDate { get; private set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? LastModifiedDate { get; private set; }

        public List<BaseDomainEvent> Events { get; private set; } = new List<BaseDomainEvent>();

        public void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            Events.Add(domainEvent);
        }

        public void RemoveDomainEvent(BaseDomainEvent domainEvent)
        {
            Events.Remove(domainEvent);
        }

        public void ChangeStatus()
        {
            IsActive = !IsActive;
        }

        public void SoftDelete()
        {
            IsSoftDeleted = true;
            IsActive = false;
        }

        public void SetCreatedBy(string userId)
        {
            CreatedBy = userId;
        }

        public void SetLastModifiedBy(string userId)
        {
            LastModifiedBy = userId;
        }

        public void SetLastModifiedDate()
        {
            LastModifiedDate = DateTimeOffset.UtcNow;
        }
    }
}
