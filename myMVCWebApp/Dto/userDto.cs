using System.ComponentModel.DataAnnotations;

namespace myMVCWebApp.Dto
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}