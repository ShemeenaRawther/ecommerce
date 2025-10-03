using Microservice.Services.AuthAPI.Models;

namespace Microservice.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}