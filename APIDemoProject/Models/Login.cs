using System.ComponentModel.DataAnnotations;

namespace APIDemoProject.Models
{
    public class Login
    {
        [Required,EmailAddress]
        public string ? Email { get; set; }

        [Required]
        public string ? Password { get; set; }
    }
}
