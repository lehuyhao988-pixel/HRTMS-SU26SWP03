using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Username không được bỏ trống.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        public required string Password { get; set; }
    }
}