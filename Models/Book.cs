using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BooksRecord.Models
{
    public class Book
    {
        [Key]
        public string bookid { get; set; }
        public string bookname { get; set; }
        public string review { get; set; }
        public bool markread { get; set; }

    }
}
