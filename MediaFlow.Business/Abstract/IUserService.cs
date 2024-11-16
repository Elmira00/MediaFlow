using MediaFlow.Entities.DTOs;

namespace MediaFlow.Business.Abstract
{
    public interface IUserService
    {
        Task<bool> Register(RegisterDto registerDto);
        Task<string?> Login(LoginDto loginDto);
        Task<bool> ChangePassword(int userId, string oldPassword, string newPassword);
    }
}
