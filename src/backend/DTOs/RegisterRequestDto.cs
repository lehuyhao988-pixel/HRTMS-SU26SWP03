using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "Username không được bỏ trống.")]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Mật khẩu phải dài từ 8 đến 50 ký tự.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Họ và tên không được bỏ trống.")]
        [MaxLength(100)]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "Email không được bỏ trống.")]
        [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Vai trò không được bỏ trống.")]
        [RegularExpression("^(Admin|Owner|Jockey|Referee|Doctor|Spectator)$",
            ErrorMessage = "Role không hợp lệ. Chỉ chấp nhận 1 trong 6 vai trò chuẩn.")]
        public required string Role { get; set; }
    }
}