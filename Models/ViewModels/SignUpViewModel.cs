using System.ComponentModel.DataAnnotations;

namespace BlazorCascadingAuth.Models.ViewModels {
    
    public class SignUpViewModel {

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        public string? ConfirmPassword { get; set; }
    }
}