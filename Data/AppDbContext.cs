using Microsoft.EntityFrameworkCore;
using BlazorCascadingAuth.Models;
using BlazorCascadingAuth.Services;

namespace BlazorCascadingAuth.Data
{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BlazorCascadingAuth.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ToDo>()
                .HasOne(t => t.User)
                .WithMany(u => u.ToDos)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Overall, when you add a to-do task to the ToDos collection of a User entity and save changes to the database, Entity Framework Core will automatically update the ToDos table to reflect the changes. 
            //  This is because of the defined relationship between the User and ToDo entities and the cascade delete behavior specified in the configuration.
            
            modelBuilder.Entity<User>()
                .HasOne(u => u.Nationality)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            var passwordHasher = new PasswordHasherService();

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Admin", Password = passwordHasher.HashPassword(new User(),"password"), Role = "Admin" },
                new User { Id = 2, Username = "User1", Password = passwordHasher.HashPassword(new User(),"password"), Role = "User" },
                new User { Id = 3, Username = "User2", Password = passwordHasher.HashPassword(new User(),"password"), Role = "User" }
            );

            modelBuilder.Entity<Nationality>().HasData(
                new Nationality { NationalityId = 1, NationalityName = "American", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132500/bflag.jpg", CountryCode = "US", Country = "United States" },
                new Nationality { NationalityId = 2, NationalityName = "British", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132502/eflag.jpg", CountryCode = "GB", Country = "United Kingdom" },
                new Nationality { NationalityId = 3, NationalityName = "French", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132504/uflag.jpg", CountryCode = "FR", Country = "France" },
                new Nationality { NationalityId = 4, NationalityName = "German", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132503/iflag.jpg", CountryCode = "DE", Country = "Germany" },
                new Nationality { NationalityId = 5, NationalityName = "Italian", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132500/bflag.jpg", CountryCode = "IT", Country = "Italy" },
                new Nationality { NationalityId = 6, NationalityName = "Spanish", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132502/eflag.jpg", CountryCode = "ES", Country = "Spain" },
                new Nationality { NationalityId = 7, NationalityName = "Japanese", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132504/uflag.jpg", CountryCode = "JP", Country = "Japan" },
                new Nationality { NationalityId = 8, NationalityName = "Chinese", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132503/iflag.jpg", CountryCode = "CN", Country = "China" },
                new Nationality { NationalityId = 9, NationalityName = "Indian", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132500/bflag.jpg", CountryCode = "IN", Country = "India" },
                new Nationality { NationalityId = 10, NationalityName = "Russian", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132502/eflag.jpg", CountryCode = "RU", Country = "Russia" },
                new Nationality { NationalityId = 11, NationalityName = "Singaporean", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132504/uflag.jpg", CountryCode = "SG", Country = "Singapore" },
                new Nationality { NationalityId = 12, NationalityName = "Malaysian", Icon = "https://media.geeksforgeeks.org/wp-content/uploads/20200630132503/iflag.jpg", CountryCode = "MY", Country = "Malaysia" }
            );

        }
    }
}
