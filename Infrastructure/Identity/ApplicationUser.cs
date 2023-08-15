using Microsoft.AspNetCore.Identity;

namespace Edgias.Humano.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public DateTime? LastSessionDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = default!;

        public DateTime? LastModifiedDate { get; set; }

        public string LastModifiedBy { get; set; } = default!;

        public string FullName => $"{FirstName} {LastName}";

        public ApplicationUser()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
