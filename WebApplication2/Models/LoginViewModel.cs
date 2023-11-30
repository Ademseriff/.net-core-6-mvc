using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    //validation rules
    public class LoginViewModel
    {
        [Required(ErrorMessage ="user name is required")]
        [StringLength(30,ErrorMessage = "ussername can be max 30 characters") ]
        public String Username { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(16)]
        public String Password { get; set; }
    }
}
