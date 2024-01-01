using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[EncryptColumn]
        public string? Code { get; set; }
    }
}
