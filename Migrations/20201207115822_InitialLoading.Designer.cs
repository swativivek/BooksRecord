﻿// <auto-generated />
using BooksRecord.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksRecord.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20201207115822_InitialLoading")]
    partial class InitialLoading
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BooksRecord.Models.Book", b =>
                {
                    b.Property<string>("bookid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("bookname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("markread")
                        .HasColumnType("bit");

                    b.Property<string>("review")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bookid");

                    b.ToTable("bkctlog");

                    b.HasData(
                        new
                        {
                            bookid = "12367",
                            bookname = "Electronics",
                            markread = false,
                            review = ""
                        },
                        new
                        {
                            bookid = "27678",
                            bookname = "Recipes for the best",
                            markread = false,
                            review = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
