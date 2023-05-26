using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Roles
    {

        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; } = string.Empty;

        public ICollection<User> users { get; set; }= new List<User>();
    }
}
