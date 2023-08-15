namespace Edgias.Humano.ApplicationCore.Entities
{
    public abstract class BaseDomainEvent
    {
        public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
