﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PTPMBTL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("PTPMQL.Models.Account", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserName");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("PTPMQL.Models.CheckAccount", b =>
                {
                    b.Property<string>("CheckUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CheckPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CheckUserName");

                    b.ToTable("CheckAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}