﻿// <auto-generated />
using System;
using BankTransfers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankTransfers.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200923091209_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("BankTransfers.Data.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("BankId")
                        .HasColumnType("int");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("BankId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankTransfers.Data.Models.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "1",
                            Name = "Физическое лицо"
                        },
                        new
                        {
                            Id = 2,
                            Code = "2",
                            Name = "Юридическое лицо"
                        },
                        new
                        {
                            Id = 3,
                            Code = "3",
                            Name = "Нерезидент"
                        });
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BIC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BIC = "044525225",
                            Name = "Сбербанк"
                        },
                        new
                        {
                            Id = 2,
                            BIC = "044525187",
                            Name = "ВТБ"
                        },
                        new
                        {
                            Id = 3,
                            BIC = "044525593",
                            Name = "Альфабанк"
                        });
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Security.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@mail.ru",
                            Password = "Kfe2prNZ+q8hlGnS//VRXKNBYeJoYrwUTqlamCPhNog=",
                            RoleId = 1,
                            Salt = "SBTSFagheVpqel2XlSuErw=="
                        });
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BankCommission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RecipientAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderAccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("TransferCommission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipientAccountId");

                    b.HasIndex("SenderAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Account", b =>
                {
                    b.HasOne("BankTransfers.Data.Models.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId");

                    b.HasOne("BankTransfers.Data.Models.Bank", "Bank")
                        .WithMany("Accounts")
                        .HasForeignKey("BankId");

                    b.Navigation("AccountType");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Security.User", b =>
                {
                    b.HasOne("BankTransfers.Data.Models.Security.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Transaction", b =>
                {
                    b.HasOne("BankTransfers.Data.Models.Account", "RecipientAccount")
                        .WithMany()
                        .HasForeignKey("RecipientAccountId");

                    b.HasOne("BankTransfers.Data.Models.Account", "SenderAccount")
                        .WithMany()
                        .HasForeignKey("SenderAccountId");

                    b.HasOne("BankTransfers.Data.Models.Security.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId");

                    b.Navigation("RecipientAccount");

                    b.Navigation("SenderAccount");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BankTransfers.Data.Models.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Bank", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Security.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BankTransfers.Data.Models.Security.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
