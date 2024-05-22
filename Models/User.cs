using System.ComponentModel.DataAnnotations;

namespace BlazorCascadingAuth.Models
{
    public class User {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Username { get; set; }
        
        [Required]
        public string? Password { get; set; }

        public string? Role { get; set; }

        public ICollection<ToDo>? ToDos { get; set; }

        public Nationality? Nationality { get; set; }

    }
}

