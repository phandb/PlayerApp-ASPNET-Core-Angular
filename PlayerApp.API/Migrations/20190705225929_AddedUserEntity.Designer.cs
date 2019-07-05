﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayerApp.API.Data;

namespace PlayerApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190705225929_AddedUserEntity")]
    partial class AddedUserEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("PlayerApp.API.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Club");

                    b.Property<DateTime>("JoinedClubOn");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PlayerApp.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
