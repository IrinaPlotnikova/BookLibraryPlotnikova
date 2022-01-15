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
        public async Task<IActionResult> Index()
        {
            AllBooksModel model = new AllBooksModel()
            {
                Books = await bookService.GetAllBooks(),
                AvailableGenres = (await genreService.GetAllGenres()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AvailableAuthors = (await authorService.GetAllAuthors()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.ShortName }),
                AvailablePublishers = (await publisherService.GetAllPublishers()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
            };
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> IndexWithFilter(AllBooksModel model)
        {
            model.Books = await bookService.GetBooksByGenresAuthorsAndPublishersId(model.BookFilter);
            model.AvailableAuthors = (await authorService.GetAllAuthors()).Select(e => new SelectListItem() {
                Value = e.Id.ToString(),
                Text = e.ShortName,
                Selected = model.BookFilter.AuthorsId.Contains(e.Id)
                });
            model.AvailableGenres = (await genreService.GetAllGenres()).Select(e => new SelectListItem() {
                Value = e.Id.ToString(),
                Text = e.Name,
                Selected = model.BookFilter.GenresId.Contains(e.Id)
                });
            model.AvailablePublishers = (await publisherService.GetAllPublishers()).Select(e => new SelectListItem() {
                Value = e.Id.ToString(),
                Text = e.Name,
                Selected = model.BookFilter.PublishersId.Contains(e.Id)
                });
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
        public async  Task<IActionResult> CreateFromModel(CreateBookModel model)
        {
            ICollection<Author> authorsFromModel = await authorService.GetAuthorsById(model.AuthorFilter);
            Book bookFromModel = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                NumberOfPages = model.NumberOfPages,
                PublishmentYear = model.PublishmentYear,
                Price = model.Price,
                GenreId = model.GenreId,
                PublisherId = model.PublisherId,
                Authors = authorsFromModel,
            };
  

            if (bookFromModel.Id == 0)
            {
                await bookService.AddBook(bookFromModel);
                for (int i = 0; i < model.NumberOfCopies; i++)
                {
                    await AddBookCopyAsync(bookFromModel);
                }
            }
            else
            {
                Book book = await bookService.GetBookById(model.Id);
                book.Name = bookFromModel.Name;
                book.NumberOfPages = bookFromModel.NumberOfPages;
                book.PublishmentYear = bookFromModel.PublishmentYear;
                book.Price = bookFromModel.Price;
                book.GenreId = bookFromModel.GenreId;
                book.PublisherId = bookFromModel.PublisherId;
                book.Authors = bookFromModel.Authors;

                await bookService.UpdateBook(book);
            }

            return RedirectToAction("Info", new { id = bookFromModel.Id});
        }

        [HttpGet]
        public async Task<IActionResult> Change(int id)
        {
            Book book = await bookService.GetBookById(id);
            AuthorFilter authorFilter = new AuthorFilter() { Ids = book.Authors.Select(e => e.Id).ToList()};
            CreateBookModel model = new CreateBookModel()
            {
                Id = id,
                Name = book.Name,
                NumberOfPages = book.NumberOfPages,
                PublishmentYear = book.PublishmentYear,
                Price = book.Price,
                GenreId = book.GenreId,
                PublisherId = book.PublisherId,
                AuthorFilter = authorFilter,
                AvailableAuthors = (await authorService.GetAllAuthors())
                                        .Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.FullName, Selected = authorFilter.Ids.Contains(e.Id) }),
                AvailableGenres = (await genreService.GetAllGenres()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
                AvailablePublishers = (await publisherService.GetAllPublishers()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
            };

            return View("Create", model);
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await bookService.DeleteBook(id);
            }
            catch (Exception) { } // повторное удаление
            return RedirectToAction("Index");
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerifyName(string name, int id)
        {
            IEnumerable<int> booksId = (await bookService.GetBooksByName(name)).Select(r => r.Id);
            return Json(booksId.Count() == 0 || booksId.Contains(id));
        }
    }
}
