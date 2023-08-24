using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.WebApp.Pages.Employees
{
    public class EmployeeIndexModel
    {
        public Guid Id { get; set; }

        public Gender Gender { get; set; }

        public string Salutation { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string NationalId { get; set; } = string.Empty;

        public int Age { get; set; }

        public string? Email { get; set; }

        public string Mobile { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }

        public string Department { get; set; } = string.Empty;

        public string? Manager { get; set; }

    }
}
