using Microsoft.AspNetCore.Identity;

namespace COMP2139_Assignment1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UsernameChangeLimit { get; set; } = 10;

        public string? FrequentFlyerNumber { get; set; }

        public byte[]? ProfilePicture { get; set; }
    }
}
