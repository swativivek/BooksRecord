using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksRecord.Models;
using BooksRecord.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace BooksRecord.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void updatereview(Book book,string bkid)
        {
            var bookid = _dbContext.bkctlog.Find(bkid);
            if (bookid.review == null)
            {
                _dbContext.Entry(bookid).State = EntityState.Detached;
                _dbContext.bkctlog.Attach(book);
                _dbContext.Entry(book).Property("review").IsModified = true;
            }
            Save();
        }
        public void markHistory(Book book,string bkid)
        {
            var dbbook = _dbContext.bkctlog.Find(bkid);
            if (dbbook.bookid != null)
            {
                _dbContext.Entry(dbbook).State = EntityState.Detached; 
                _dbContext.bkctlog.Attach(book);
                _dbContext.Entry(book).Property("markread").IsModified = true;
                Save();
            }
          
        }
        public void deletebook(string bkid)
        {
            var product = _dbContext.bkctlog.Find(bkid);
            _dbContext.bkctlog.Remove(product);
            Save();
        }

        public Book getbookbyid(string bkid)
        {
            return _dbContext.bkctlog.Find(bkid);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.bkctlog.ToList();
        }

        public void insertbook(Book book)
        {

            _dbContext.Add(book);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void updatebook(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            Save();
        }
    }
}
