using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }=string.Empty;
        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public Roles? Role { get; set; } 
    }
}
