using Microsoft.AspNetCore.Identity;

namespace Tutorial.Core.Entities
{
    // needs inheritance from IdentityUser for MicrosoftIdentity
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSeller { get; set; }
        public bool IsBuyer { get; set; }
    }
}
