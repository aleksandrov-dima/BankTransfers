using BankTransfers.Data.Models.Security;
using Microsoft.EntityFrameworkCore;

namespace BankTransfers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //при создании БД добавляем роли Администратора и обычного пользователя
            string adminRoleName = "admin";
            string userRoleName = "user";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });


            //добавляем для тестов пользователя с админской ролью
            string adminEmail = "admin@mail.ru";

            User adminUser = new User
            {
                Id = 1,
                Email = adminEmail,
                Password = "Kfe2prNZ+q8hlGnS//VRXKNBYeJoYrwUTqlamCPhNog=",//хэш пароля "SuperAdmin3"
                Salt = "SBTSFagheVpqel2XlSuErw==",//хэш соли
                RoleId = adminRole.Id
            };

            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}