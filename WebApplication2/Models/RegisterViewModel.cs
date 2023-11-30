using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "user name is required")]
        [StringLength(30, ErrorMessage = "ussername can be max 30 characters")]
        public String Username { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(16)]
        public String Password { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(16)]
        [Compare(nameof(Password))]
        public String RePassword { get; set; }
    }
}
