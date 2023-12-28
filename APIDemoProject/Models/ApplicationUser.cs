using Microsoft.AspNetCore.Identity;

namespace APIDemoProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string  FirstName { get; set; }

        public string LastName { get; set; }
    }
}
