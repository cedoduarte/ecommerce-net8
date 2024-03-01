﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ecommerce.Models;

#nullable disable

namespace ecommerce.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240226025434_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ecommerce.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("TINYINT(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(10, 2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ecommerce.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("TINYINT(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("DATETIME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("VARCHAR(128)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<long>("Type")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("VARCHAR(16)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
