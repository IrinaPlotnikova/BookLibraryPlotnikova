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
            bookFilter ??= new BookFilter();

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

            return View(model);
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

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Book book, [FromForm] AuthorFilter authorFilter, [FromForm] int numberOfCopies)
        {
            if (!await VerifyBook(book)) 
            {
                return BadRequest();
            }

            if (!await VerifyDistinctBookName(book.Name))
            {
                ModelState.AddModelError("Name", "Книга с таким названием уже зарегистрирована");
            }

            if (!ModelState.IsValid)
            {
                CreateBookModel model = new CreateBookModel()
                {
                    Name = book.Name,
                    NumberOfPages = book.NumberOfPages,
                    PublishmentYear = book.PublishmentYear,
                    NumberOfCopies = numberOfCopies,
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

                return View("Create", model);
            }

            book.Authors = await authorService.GetAuthorsById(authorFilter);
            await bookService.CreateBook(book);

            ICollection<BookCopy> copies = CreateBookCopies(book.Id, numberOfCopies, DateTime.Today);
            await bookCopyService.CreateBookCopies(copies);

            ICollection<MoneyTransaction> transactions = CreateMoneyTransactionsForBuyingCopies(copies, book.Price);
            await moneyTransactionService.CreateMoneyTransactions(transactions);

            return RedirectToAction(nameof(Info), new { id = book.Id});
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Book book = await bookService.GetBookById(id);
            if (book == null)
            {
                 return NotFound();
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

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Book bookFromModel, [FromForm] AuthorFilter authorFilter)
        {
            Book book = await bookService.GetBookById(bookFromModel.Id);
            if (book == null)
            {
                return NotFound();
            }

            if (!await VerifyBook(bookFromModel))
            {
                return BadRequest();
            }

            if (!await VerifyDistinctBookName(bookFromModel.Name, bookFromModel.Id))
            {
                ModelState.AddModelError("Name", "Книга с таким названием уже существует");
            }

            if (!ModelState.IsValid)
            {
                UpdateBookModel model =  new UpdateBookModel()
                {
                    Id = bookFromModel.Id,
                    Name = bookFromModel.Name,
                    NumberOfPages = bookFromModel.NumberOfPages,
                    PublishmentYear = bookFromModel.PublishmentYear,
                    Price = bookFromModel.Price,
                    GenreId = bookFromModel.GenreId,
                    PublisherId = bookFromModel.PublisherId,
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
            

            ICollection<Author> authors = await authorService.GetAuthorsById(authorFilter);
            book.Name = bookFromModel.Name;
            book.NumberOfPages = bookFromModel.NumberOfPages;
            book.PublishmentYear = bookFromModel.PublishmentYear;
            book.Price = bookFromModel.Price;
            book.GenreId = bookFromModel.GenreId;
            book.PublisherId = bookFromModel.PublisherId;
            book.Authors = authors;
            await bookService.UpdateBook(book);

            return RedirectToAction(nameof(Info), new { id = book.Id});
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Book book = await bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await bookService.GetBookById(id) == null)
            {
                return NotFound();
            }

            await bookService.DeleteBook(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Book book = await bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            BookInfoModel model = new BookInfoModel()
            {
                Book = book,
                BookCopiesLibrary = book.BookCopies.Where(e => e.ReaderId == null),
                BookCopiesReader = book.BookCopies.Where(e => e.ReaderId != null),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCopy(int bookId)
        {
            Book book = await bookService.GetBookById(bookId);
            if (book == null)
            {
                return NotFound();
            }
            await AddBookCopyAsync(book);

            return RedirectToAction(nameof(Index));
        }

        private ICollection<BookCopy> CreateBookCopies(int bookId, int numberOfCopies, DateTime dateAdded) 
        { 
            ICollection<BookCopy> copies = new List<BookCopy>();
            for (int i = 0; i < numberOfCopies; i++)
            {
                BookCopy copy = new BookCopy()
                {
                    BookId = bookId,
                    ReaderId = null,
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
            BookCopy bookCopy = new BookCopy() { BookId = book.Id, ReaderId = null, DateAdded = DateTime.Today };
            await bookCopyService.CreateBookCopy(bookCopy);
            MoneyTransaction transaction = new MoneyTransaction()
            {
                BookCopyId = bookCopy.Id,
                MoneyTransactionTypeId = 1,
                AmountOfMoney = book.Price,
                Date = bookCopy.DateAdded
            };
            await moneyTransactionService.CreateMoneyTransaction(transaction);
        }

        private async Task<bool> VerifyBook(Book book)
        {
            if (book == null) 
                return false;
            
            return !string.IsNullOrWhiteSpace(book.Name) && book.Name.Length <= 100 &&
                1 <= book.NumberOfPages && book.NumberOfPages <= int.MaxValue &&
                1800 <= book.PublishmentYear && book.PublishmentYear <= DateTime.Today.Year &&
                1 <= book.Price && book.Price <= int.MaxValue &&
                (book.GenreId == null || (await genreService.GetGenderById(book.GenreId.Value)) != null) &&
                (book.PublisherId == null || (await publisherService.GetPublisherById(book.PublisherId.Value)) != null);
        }


        private async Task<bool> VerifyDistinctBookName(string name, int id = 0)
        {
            if (name == null)
                return false;

            IEnumerable<int> booksId = (await bookService.GetBooksByName(name)).Select(e => e.Id);
            return !booksId.Any() || booksId.Contains(id);
        }
    }
}
