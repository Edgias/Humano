using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Rate : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = default!;

        public decimal Amount { get; private set; }

        public Rate(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
