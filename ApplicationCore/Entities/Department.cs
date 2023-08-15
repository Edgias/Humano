using Edgias.Humano.ApplicationCore.Interfaces;

namespace Edgias.Humano.ApplicationCore.Entities
{
    public class Department : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = string.Empty;

        public string? Email { get; private set; }

        public Department(string name, string? email)
        {
            Name = name;
            Email = email;
        }
    }
}
