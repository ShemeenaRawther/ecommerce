using Microsoft.AspNetCore.Identity;

namespace Microservice.Services.AuthAPI.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }
    }
}
