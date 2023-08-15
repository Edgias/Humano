using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Salutation : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;

        public Salutation(string name)
        {
            Name = name;
        }
    }
}
