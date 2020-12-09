using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksRecord.Models;

namespace BooksRecord.DBContexts
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        
    public DbSet<Book> bkctlog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    bookid = "12367",
                    bookname = "Electronics",
                    review = "",
                    markread=false,
                },
                new Book
                {
                    bookid = "27678",
                    bookname = "Recipes for the best",
                    review = "",
                    markread=false,
                }

            );
        }
     
    }
}
