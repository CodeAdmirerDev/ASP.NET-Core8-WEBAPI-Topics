using DemoServerAppForHMAC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoServerAppForHMAC.Context
{
    public class ServerAppDbContext : DbContext
    {
        public ServerAppDbContext(DbContextOptions<ServerAppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.ClientInfo> ClientInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>().HasData(
                new Models.User
                {
                    Id = 1,
                    Username = "Rama",
                    UserRole = "Software Engineer",
                    Salary = 10000
                },
                new Models.User
                {
                    Id = 2,
                    Username = "Krishna",
                    UserRole = "Manager",
                    Salary = 500000
                }
            );

            modelBuilder.Entity<Models.ClientInfo>().HasData(
                new Models.ClientInfo
                {
                    Id = 1,
                    ClientId = "WebApp",
                    ClientName = "XYZ Company",
                    //ClientSecretKey = SamplePasswordHasher.CreatePasswordHash("WebAppXYZCompany", out byte[] passwordHash, out byte[] passwordSalt),
                    //ClientSecretSalt = passwordSalt  ==> Due to the limitation of the EF Core, we can't use the above code(dynamic) to generate the password hash and salt. So, we have to use the below code to generate the password hash and salt.
                    ClientSecretKey = "XYZCompany123",
                    ClientSecretSalt = "Test"

                },
                new Models.ClientInfo
                {
                    Id = 2,
                    ClientId = "MobileApp",
                    ClientName = "ABC Company",
                    ClientSecretKey = "XYZCompany123",
                    ClientSecretSalt = "Test"
                }
                ,
                new Models.ClientInfo
                {
                    Id = 3,
                    ClientId = "DeskTop",
                    ClientName = "123 Company",
                    ClientSecretKey = "XYZCompany123",
                    ClientSecretSalt = "Test"
                }
            );
        }
    }
}
