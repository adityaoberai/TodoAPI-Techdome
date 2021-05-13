using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            LoadUsers();
        }

        public DbSet<User> Users { get; set; }

        public void LoadUsers() // Dummy Data
        {
            var users = new List<User>
            {
                new User()
                {
                    FirstName = "Aditya",
                    LastName = "Oberai",
                    Email = "adityaoberai1@gmail.com",
                    IsActive = false,
                    Role = "Admin",
                    Password = "pass1234"
                }, // Admin Role

                new User()
                {
                    FirstName = "Foo",
                    LastName = "Bar",
                    Email = "foo@bar.xyz",
                    IsActive = false,
                    Role = "User",
                    Password = "pass1234"
                } // User Role
            };
            Users.AddRange(users);
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Email);
        }
    }
}
