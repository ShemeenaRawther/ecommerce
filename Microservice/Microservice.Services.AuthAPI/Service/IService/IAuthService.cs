using Microservice.Services.AuthAPI.Models.Dto;

namespace Microservice.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> RegisterUser(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> LoginUser(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
