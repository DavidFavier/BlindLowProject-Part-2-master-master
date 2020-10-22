﻿// <auto-generated />
using BlindLowVisionProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlindLowVisionProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201022010222_AddSomeProperty")]
    partial class AddSomeProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlindLowVisionProject.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhotoPat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SomeProperty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 2,
                            Email = "nikhil@gmail.com",
                            Name = "Nikhil",
                            SomeProperty = 0
                        },
                        new
                        {
                            Id = 2,
                            Department = 1,
                            Email = "DrRohanP@gmail.com",
                            Name = "DrRohanPatel",
                            SomeProperty = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}