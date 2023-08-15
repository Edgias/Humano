using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class JobTitle : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = string.Empty;

        public JobTitle(string name)
        {
            Name = name;
        }
    }
}
