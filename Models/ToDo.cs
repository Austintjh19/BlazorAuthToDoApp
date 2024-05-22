using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCascadingAuth.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public string? TaskName { get; set; }
        public DateTime Deadline { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
