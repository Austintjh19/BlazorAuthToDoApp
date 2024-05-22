using BlazorCascadingAuth.Models;
using Microsoft.AspNetCore.Identity;

namespace BlazorCascadingAuth.Services {
        public class PasswordHasherService{
        private readonly PasswordHasher<User> passwordHasher;

        public PasswordHasherService(){
            passwordHasher = new PasswordHasher<User>();
        }

        public string HashPassword(User user, string password){
            return passwordHasher.HashPassword(user, password);
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword){
            return passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        }
    }
}