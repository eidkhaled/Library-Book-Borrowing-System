﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240220075919_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataBase.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("AuthorBio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DataBase.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublicationYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DataBase.BookAuthor", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("DataBase.BookCopy", b =>
                {
                    b.Property<int>("CopyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CopyId"), 1L, 1);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CopyId");

                    b.HasIndex("BookID");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("DataBase.BorrowingRecords", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowId"), 1L, 1);

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CopyType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("bookCopyCopyId")
                        .HasColumnType("int");

                    b.HasKey("BorrowId");

                    b.HasIndex("bookCopyCopyId");

                    b.ToTable("BorrowingRecords");
                });

            modelBuilder.Entity("DataBase.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataBase.Book", b =>
                {
                    b.HasOne("DataBase.Category", "Category")
                        .WithMany("books")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DataBase.BookAuthor", b =>
                {
                    b.HasOne("DataBase.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Book", "Book")
                        .WithMany("Author")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DataBase.BookCopy", b =>
                {
                    b.HasOne("DataBase.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DataBase.BorrowingRecords", b =>
                {
                    b.HasOne("DataBase.BookCopy", "bookCopy")
                        .WithMany()
                        .HasForeignKey("bookCopyCopyId");

                    b.Navigation("bookCopy");
                });

            modelBuilder.Entity("DataBase.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DataBase.Book", b =>
                {
                    b.Navigation("Author");
                });

            modelBuilder.Entity("DataBase.Category", b =>
                {
                    b.Navigation("books");
                });
#pragma warning restore 612, 618
        }
    }
}
