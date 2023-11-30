using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Entities
{
    [Table("Users")]//database tarafında oluşturulacak olan tablonun adını verdik.
    public partial class User
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public String? Fullname { get; set; } = null; //string değeri boş değer alabilir gibisinden ? koyuyoruz.
        [Required]
        [StringLength(30)]
        public String Username { get; set; }
        [Required]
        [StringLength(100)]
        public String Password { get; set; }

        public bool Locked { get; set; } = false;

        public DateTime Createdtime { get; set; } = DateTime.Now;


    }
}
