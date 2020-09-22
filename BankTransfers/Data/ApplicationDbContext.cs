using BankTransfers.Models.Security;
using Microsoft.EntityFrameworkCore;

namespace BankTransfers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

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
            string adminPassword = "SuperAdmin3";

            //получаем хэш пароля (+ соль)
            var hashedPassword = PasswordHelper.GetSaltedHashedPassword(adminPassword, out string salt);

            User adminUser = new User
            {
                Id = 1,
                Email = adminEmail,
                Password = hashedPassword,
                Salt = salt,
                RoleId = adminRole.Id
            };

            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}