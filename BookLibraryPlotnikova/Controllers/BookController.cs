using BLL.Filters;
using BLL.Interfaces;
using Domain.Entities;
using LibraryPlotnikova.Models;
using LibraryPlotnikova.Models.BookModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;
        private readonly IBookCopyService bookCopyService;
        private readonly IMoneyTransactionService moneyTransactionService;

        public BookController(IBookService bookService, IAuthorService authorService, IGenreService genreService, IPublisherService publisherService,
                              IBookCopyService bookCopyService, IMoneyTransactionService moneyTransactionService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.genreService = genreService;
            this.publisherService = publisherService;
            this.bookCopyService = bookCopyService;
            this.moneyTransactionService = moneyTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] BookFilter bookFilter)
        {
            if (bookFilter == null)
            {
                bookFilter = new BookFilter();
            }

            AllBooksModel model = new AllBooksModel()
            {
                Books = await bookService.GetBooksByGenresAuthorsAndPublishersId(bookFilter),
                AvailableGenres = (await genreService.GetAllGenres()).Select(e => new SelectListItem() 
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = bookFilter.GenresId.Contains(e.Id)
                    }),
                AvailableAuthors = (await authorService.GetAllAuthors()).Select(e => new SelectListItem() 
                    {
                        Value = e.Id.ToString(),
                        Text = e.ShortName,
                        Selected = bookFilter.AuthorsId.Contains(e.Id)
                    }),
                AvailablePublishers = (await publisherService.GetAllPublishers()).Select(e => new SelectListItem() 
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = bookFilter.PublishersId.Contains(e.Id)
                    }),
            };
            return View("Index", model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateBookModel model =  new CreateBookModel()
            {
                AvailableAuthors = (await authorService.GetAllAuthors()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.FullName }),
                AvailableGenres = (await genreService.GetAllGenres()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AvailablePublishers = (await publisherService.GetAllPublishers()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AuthorFilter = new AuthorFilter()
            };
            return View("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Book book, [FromForm] AuthorFilter authorFilter, [FromForm] int numberOfCopies)
        {
            if (book == null || !await VerifyBook(book))
            {
                return RedirectToAction("Index");
            }
            ICollection<Author> authors = await authorService.GetAuthorsById(authorFilter);
            book.Authors = authors;
            await bookService.AddBook(book);

            DateTime date = DateTime.Today;
            ICollection<BookCopy> copies = CreateBookCopies(book.Id, numberOfCopies, date);
            await bookCopyService.AddBookCopies(copies);

            ICollection<MoneyTransaction> transactions = CreateMoneyTransactionsForBuyingCopies(copies, book.Price);
            await moneyTransactionService.AddMoneyTransactions(transactions);

            return RedirectToAction("Info", new { id = book.Id});
        }

         [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Book book = await bookService.GetBookById(id);
            if (book == null)
            {
                 return RedirectToAction("Index");
            }

            AuthorFilter authorFilter = new AuthorFilter()
                {
                    Ids = book.Authors.Select(e => e.Id).ToList(),
                };
            UpdateBookModel model =  new UpdateBookModel()
            {
                Id = id,
                Name = book.Name,
                NumberOfPages = book.NumberOfPages,
                PublishmentYear = book.PublishmentYear,
                Price = book.Price,
                GenreId = book.GenreId,
                PublisherId = book.PublisherId,
                AuthorFilter = authorFilter,
                AvailableAuthors = (await authorService.GetAllAuthors()).Select(e => new SelectListItem() 
                    { 
                        Value = e.Id.ToString(), 
                        Text = e.FullName, 
                        Selected = authorFilter.Ids.Contains(e.Id) 
                    }),
                AvailableGenres = (await genreService.GetAllGenres()).Select(e => new SelectListItem() 
                    { 
                        Value = e.Id.ToString(), 
                        Text = e.Name 
                    }),
                AvailablePublishers = (await publisherService.GetAllPublishers()).Select(e => new SelectListItem() 
                    { 
                        Value = e.Id.ToString(), 
                        Text = e.Name 
                    }),
            };
            return View("Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Book bookFromModel, [FromForm] AuthorFilter authorFilter)
        {
            if (bookFromModel == null || !await VerifyBook(bookFromModel))
            {
                return RedirectToAction("Index");
            }

            Book book = await bookService.GetBookById(bookFromModel.Id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }

            ICollection<Author> authors = await authorService.GetAuthorsById(authorFilter);
            book.Name = bookFromModel.Name;
            book.NumberOfPages = bookFromModel.NumberOfPages;
            book.PublishmentYear = bookFromModel.PublishmentYear;
            book.Price = bookFromModel.Price;
            book.GenreId = bookFromModel.GenreId;
            book.PublisherId = bookFromModel.PublisherId;
            book.Authors = authors;
            
            await bookService.UpdateBook(book);
            return RedirectToAction("Info", new { id = book.Id});
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Book book = await bookService.GetBookById(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View("ConfirmDeletion", book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await bookService.GetBookById(id) != null)
            {
                await bookService.DeleteBook(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Book book = await bookService.GetBookById(id);
            BookInfoModel model = new BookInfoModel()
            {
                Book = book,
                BookCopiesLibrary = book.BookCopies.Where(e => e.BookStatusId == 1),
                BookCopiesReader = book.BookCopies.Where(e => e.BookStatusId == 2),
            };
            return View("Info", model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCopy(int bookId)
        {
            Book book = await bookService.GetBookById(bookId);
            await AddBookCopyAsync(book);
            return RedirectToAction("Index");
        }

        private ICollection<BookCopy> CreateBookCopies(int bookId, int numberOfCopies, DateTime dateAdded) 
        { 
            ICollection<BookCopy> copies = new List<BookCopy>();
            for (int i = 0; i < numberOfCopies; i++)
            {
                BookCopy copy = new BookCopy()
                {
                    BookId = bookId,
                    BookStatusId = 1,
                    DateAdded = dateAdded,
                };
                copies.Add(copy);
            }

            return copies;
        }

        private ICollection<MoneyTransaction> CreateMoneyTransactionsForBuyingCopies(ICollection<BookCopy> copies, int price)
        {
            ICollection<MoneyTransaction> transactions = new List<MoneyTransaction>();

            foreach(BookCopy copy in copies)
            {
                MoneyTransaction transaction = new MoneyTransaction()
                {
                    BookCopyId = copy.Id,
                    MoneyTransactionTypeId = 1,
                    AmountOfMoney = price,
                    Date = copy.DateAdded,
                };

                transactions.Add(transaction);
            }

            return transactions;
        }

        private async Task AddBookCopyAsync(Book book)
        {
            BookCopy bookCopy = new BookCopy() { BookId = book.Id, BookStatusId = 1, DateAdded = DateTime.Today };
            await bookCopyService.AddBookCopy(bookCopy);
            MoneyTransaction transaction = new MoneyTransaction()
            {
                BookCopyId = bookCopy.Id,
                MoneyTransactionTypeId = 1,
                AmountOfMoney = book.Price,
                Date = bookCopy.DateAdded
            };
            await moneyTransactionService.AddMoneyTransaction(transaction);
        }

        private async Task<bool> VerifyBook(Book book)
        {
            IEnumerable<int> booksId = (await bookService.GetBooksByName(book.Name)).Select(e => e.Id);
            return !string.IsNullOrWhiteSpace(book.Name) && book.Name.Length <= 100 && (!booksId.Any() || booksId.Contains(book.Id)) &&
                1 <= book.NumberOfPages && book.NumberOfPages <= int.MaxValue &&
                1800 <= book.PublishmentYear && book.PublishmentYear <= DateTime.Today.Year &&
                1 <= book.Price && book.Price <= int.MaxValue &&
                (book.GenreId == null || (await genreService.GetGenderById(book.GenreId.Value)) != null) &&
                (book.PublisherId == null || (await publisherService.GetPublisherById(book.PublisherId.Value)) != null);
        }
    }
}
