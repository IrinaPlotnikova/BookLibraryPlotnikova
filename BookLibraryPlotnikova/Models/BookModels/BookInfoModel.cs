using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models.BookModels
{
    public class BookInfoModel
    {
        public Book Book { get; set; } = new Book();

        public IEnumerable<BookCopy> BookCopiesLibrary { get; set; } = new List<BookCopy>();

        public IEnumerable<BookCopy> BookCopiesReader { get; set; } = new List<BookCopy>();
    }
}
