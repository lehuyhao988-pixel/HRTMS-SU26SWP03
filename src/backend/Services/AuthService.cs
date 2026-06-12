using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool IsSuccess, string ErrorMessage, int UserId)> RegisterAsync(RegisterRequestDto request)
        {
            try
            {
                bool userExists = await _context.Users.AnyAsync(u => u.Username == request.Username || u.Email == request.Email);
                if (userExists)
                {
                    return (false, "Username hoặc Email đã được sử dụng.", 0);
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, workFactor: 12);

                string initialStatus = (request.Role == "Admin" || request.Role == "Spectator" || request.Role == "Owner")
                                        ? "Active" : "Pending";

                var newUser = new User
                {
                    Username = request.Username,
                    FullName = request.FullName,
                    Email = request.Email,
                    Role = request.Role,
                    PasswordHash = passwordHash,
                    Status = initialStatus
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return (true, string.Empty, newUser.UserId);
            }
            catch (DbUpdateException)
            {
                return (false, "Lỗi hệ thống: Dữ liệu bị trùng lặp trong quá trình xử lý đồng thời.", 0);
            }
        }
    }
}