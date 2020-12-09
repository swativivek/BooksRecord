using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksRecord.Models;
namespace BooksRecord.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        void updatereview(Book book,string bkid);
        Book getbookbyid(string bkid);
        void insertbook(Book book);
        void deletebook(string bkid);
        void updatebook(Book book);
        void markHistory(Book book,string bkid);
        void Save();

    }
}
