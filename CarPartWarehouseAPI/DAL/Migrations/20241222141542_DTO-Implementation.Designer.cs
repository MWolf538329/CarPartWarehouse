﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241222141542_DTO-Implementation")]
    partial class DTOImplementation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.DataModels.CategoryDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DAL.DataModels.ProductDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CurrentStock")
                        .HasColumnType("int");

                    b.Property<int>("MaxStock")
                        .HasColumnType("int");

                    b.Property<int>("MinStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SubcategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SubcategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DAL.DataModels.ProductLinkDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ProductDTOID")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ProductDTOID");

                    b.ToTable("ProductLinks");
                });

            modelBuilder.Entity("DAL.DataModels.StockHistoryDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StockChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StockNow")
                        .HasColumnType("int");

                    b.Property<int>("StockWas")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("StockHistories");
                });

            modelBuilder.Entity("DAL.DataModels.SubcategoryDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("DAL.DataModels.ProductDTO", b =>
                {
                    b.HasOne("DAL.DataModels.SubcategoryDTO", "Subcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("DAL.DataModels.ProductLinkDTO", b =>
                {
                    b.HasOne("DAL.DataModels.ProductDTO", null)
                        .WithMany("Links")
                        .HasForeignKey("ProductDTOID");
                });

            modelBuilder.Entity("DAL.DataModels.StockHistoryDTO", b =>
                {
                    b.HasOne("DAL.DataModels.ProductDTO", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DAL.DataModels.SubcategoryDTO", b =>
                {
                    b.HasOne("DAL.DataModels.CategoryDTO", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DAL.DataModels.CategoryDTO", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("DAL.DataModels.ProductDTO", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("DAL.DataModels.SubcategoryDTO", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
