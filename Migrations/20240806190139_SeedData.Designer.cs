﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APITest.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20240806190139_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APITest.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Category1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Category2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Category3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Category4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Category5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Category6"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Category7"
                        });
                });

            modelBuilder.Entity("APITest.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 6,
                            Description = "Description1",
                            Name = "Product1",
                            Price = 10.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Description2",
                            Name = "Product2",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Description3",
                            Name = "Product3",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 5,
                            Description = "Description4",
                            Name = "Product4",
                            Price = 40.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Description = "Description5",
                            Name = "Product5",
                            Price = 50.0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 6,
                            Description = "Description6",
                            Name = "Product6",
                            Price = 60.0
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 5,
                            Description = "Description7",
                            Name = "Product7",
                            Price = 70.0
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Description = "Description8",
                            Name = "Product8",
                            Price = 80.0
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Description = "Description9",
                            Name = "Product9",
                            Price = 90.0
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Description = "Description10",
                            Name = "Product10",
                            Price = 100.0
                        });
                });

            modelBuilder.Entity("APITest.Models.Product", b =>
                {
                    b.HasOne("APITest.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("APITest.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
