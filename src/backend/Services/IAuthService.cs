using Backend.DTOs;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IAuthService
    {
        Task<(bool IsSuccess, string ErrorMessage, int UserId)> RegisterAsync(RegisterRequestDto request);
    }
}