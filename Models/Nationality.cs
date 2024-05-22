using System.ComponentModel.DataAnnotations;

namespace BlazorCascadingAuth.Models
{

    public class Nationality {

        [Key]
        public int NationalityId { get; set; }

        [Required]
        public string? NationalityName { get; set; }

        public string? Icon { get; set; }

        [Required]
        public string? CountryCode { get; set; }

        [Required]
        public string? Country { get; set; }

    }

}