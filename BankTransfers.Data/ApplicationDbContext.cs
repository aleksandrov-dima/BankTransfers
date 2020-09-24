using System.Collections.Generic;
using BankTransfers.Data.Models;
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
        
        public DbSet<AccountType> AccountTypes { get; set; }
        
        public DbSet<Bank> Banks { get; set; }
        
        public DbSet<Account> Accounts { get; set; }
        
        public DbSet<Transaction> Transactions { get; set; }
        
        public DbSet<BankCommision> BankCommisions { get; set; }
        
        public DbSet<BankTransferType> BankTransferTypes { get; set; }
        
        public DbSet<TransferCommision> TransferCommisions { get; set; }
        
        
        
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
            
            //заполнение справочника Типы счетов
            var accountTypes = new[]
            {
                new AccountType() {Id = 1, Code = "1", Name = "Физическое лицо"},
                new AccountType() {Id = 2, Code = "2", Name = "Юридическое лицо"},
                new AccountType() {Id = 3, Code = "3", Name = "Нерезидент"}
            };
            modelBuilder.Entity<AccountType>().HasData(accountTypes);
            
            //заполнение справочника Банки
            var banks = new[]
            {
                new Bank() {Id = 1, BIC = "044525225", Name = "Сбербанк"},
                new Bank() {Id = 2, BIC = "044525187", Name = "ВТБ"},
                new Bank() {Id = 3, BIC = "044525593", Name = "Альфабанк"}
            };
            modelBuilder.Entity<Bank>().HasData(banks);
            
            //заполнение матрицы коммисий переводов
            var transferCommisions = new List<TransferCommision>()
            {
                new TransferCommision()
                {
                    Id = 1,
                    SenderAccountTypeId = 1, //Физическое лицо
                    RecipientAccountTypeId = 1, //Физическое лицо
                    Rate = 0m
                },
                new TransferCommision()
                {
                    Id = 2,
                    SenderAccountTypeId = 1, //Физическое лицо
                    RecipientAccountTypeId = 2, //Юридическое лицо
                    Rate = 0m
                },
                new TransferCommision()
                {
                    Id = 3,
                    SenderAccountTypeId = 1, //Физическое лицо
                    RecipientAccountTypeId = 3, //Нерезидент
                    Rate = 0m
                },
                new TransferCommision()
                {
                    Id = 4,
                    SenderAccountTypeId = 2, //Юридическое лицо
                    RecipientAccountTypeId = 1, //Физическое лицо
                    Rate = 2.0m
                },
                new TransferCommision()
                {
                    Id = 5,
                    SenderAccountTypeId = 2, //Юридическое лицо
                    RecipientAccountTypeId = 2, //Юридическое лицо
                    Rate = 3.0m
                },
                new TransferCommision()
                {
                    Id = 6,
                    SenderAccountTypeId = 2, //Юридическое лицо
                    RecipientAccountTypeId = 3, //Нерезидент
                    Rate = 4.0m
                },
                new TransferCommision()
                {
                    Id = 7,
                    SenderAccountTypeId = 3, //Нерезидент
                    RecipientAccountTypeId = 1, //Физическое лицо
                    Rate = 4.0m
                },
                new TransferCommision()
                {
                    Id = 8,
                    SenderAccountTypeId = 3, //Нерезидент
                    RecipientAccountTypeId = 2, //Юридическое лицо
                    Rate = 6.0m
                },
                new TransferCommision()
                {
                    Id = 9,
                    SenderAccountTypeId = 3, //Нерезидент
                    RecipientAccountTypeId = 3, //Нерезидент
                    Rate = 6.0m
                }
            };
            modelBuilder.Entity<TransferCommision>().HasData(transferCommisions);
            
            //заполнение матрицы коммисий банков
            modelBuilder.Entity<BankTransferType>().HasData(new[]
            {
                new BankTransferType() {Id = 1, Name = "Внутренний перевод"},
                new BankTransferType() {Id = 2, Name = "На счет в другом банке"}
            });

            var bankCommisions = new List<BankCommision>()
            {
                new BankCommision()
                {
                    Id = 1,
                    BankId = 1, //Сбербанк
                    BankTransferTypeId = 1, //Внутренний перевод
                    Rate = 0m
                },
                new BankCommision()
                {
                    Id = 2,
                    BankId = 1, //Сбербанк
                    BankTransferTypeId = 2, //На счет в другом банке
                    Rate = 1.0m
                },
                new BankCommision()
                {
                    Id = 3,
                    BankId = 2, //ВТБ
                    BankTransferTypeId = 1, //Внутренний перевод
                    Rate = 0m
                },
                new BankCommision()
                {
                    Id = 4,
                    BankId = 2, //ВТБ
                    BankTransferTypeId = 2, //На счет в другом банке
                    Rate = 2.0m
                },
                new BankCommision()
                {
                    Id = 5,
                    BankId = 3, //Альфабанк
                    BankTransferTypeId = 1, //Внутренний перевод
                    Rate = 1.0m
                },
                new BankCommision()
                {
                    Id = 6,
                    BankId = 3, //Альфабанк
                    BankTransferTypeId = 2, //На счет в другом банке
                    Rate = 2.5m
                }
            };
            modelBuilder.Entity<BankCommision>().HasData(bankCommisions);

            var accountList = new List<Account>()
            {
                new Account() {Id = 1, Deposit = 31000, AccountTypeId = 1, BankId = 1},
                new Account() {Id = 2, Deposit = 25000, AccountTypeId = 2, BankId = 1},
                new Account() {Id = 3, Deposit = 15020, AccountTypeId = 3, BankId = 1},
                new Account() {Id = 4, Deposit = 5000, AccountTypeId = 1, BankId = 2},
                new Account() {Id = 5, Deposit = 2000, AccountTypeId = 2, BankId = 2},
                new Account() {Id = 6, Deposit = 100, AccountTypeId = 3, BankId = 2},
                new Account() {Id = 7, Deposit = 3000, AccountTypeId = 1, BankId = 3},
                new Account() {Id = 8, Deposit = 300, AccountTypeId = 2, BankId = 3},
                new Account() {Id = 9, Deposit = 35000, AccountTypeId = 3, BankId = 3}
            };

            modelBuilder.Entity<Account>().HasData(accountList);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}