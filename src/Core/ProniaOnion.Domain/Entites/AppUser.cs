using Microsoft.AspNetCore.Identity;
namespace ProniaOnion.src.Domain
{
    public class AppUser:IdentityUser
    {

        public string Name { get; set; }
        public string Surname { get; set; } 

        public bool IsActive { get; set; }

    }
}