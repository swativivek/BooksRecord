using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksRecord.Models;
using BooksRecord.Repository;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksRecord.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
       
            private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
            public IActionResult Get()
            {
                var products = _bookRepository.GetBooks();
                return new OkObjectResult(products);
            }
        [HttpPut("{id}", Name = "Put")]
        public IActionResult Put([FromBody] Book book,string id)
        {
            if (book != null)
            {
                using (var scope = new TransactionScope())
                {
                    _bookRepository.updatereview(book,id);
                    if (book.markread == true)
                        _bookRepository.markHistory(book, id);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        //[HttpPut("{mark}", Name = "Put")]
        //public IActionResult Put([FromBody] Book book, bool mark)
        //{
        //    if (book != null)
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            _bookRepository.markHistory(book,mark);
        //            scope.Complete();
        //            return new OkResult();
        //        }
        //    }
        //    return new NoContentResult();
        //}
        [HttpGet("{id}", Name = "Get")]
            public IActionResult Get(string id)
            {
                var product = _bookRepository.getbookbyid(id);
                return new OkObjectResult(product);
            }

            [HttpPost]
            public IActionResult Post([FromBody] Book book)
            {
                using (var scope = new TransactionScope())
                {
                    _bookRepository.insertbook(book);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = book.bookid }, book);
                }
            }

            [HttpPut]
            public IActionResult Put([FromBody] Book book)
            {
                if (book != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _bookRepository.updatebook(book);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(string id)
            {
                _bookRepository.deletebook(id);
                return new OkResult();
            }
        }
}
