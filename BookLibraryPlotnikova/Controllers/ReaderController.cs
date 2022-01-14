using BLL.Filters;
using BLL.Interfaces;
using Domain.Entities;
using LibraryPlotnikova.Models;
using LibraryPlotnikova.Models.ReaderModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderService readerService;
        private readonly IBookService bookService;
        private readonly IBookCopyService bookCopyService;
        private readonly IBookCheckoutService bookCheckoutService;
        private readonly IMoneyTransactionService moneyTransactionService;

        public ReaderController(IReaderService readerService, IBookService bookService, IBookCopyService bookCopyService, IBookCheckoutService bookCheckoutService,
                                IMoneyTransactionService moneyTransactionService)
        {
            this.readerService = readerService;
            this.bookService = bookService;
            this.bookCopyService = bookCopyService;
            this.bookCheckoutService = bookCheckoutService;
            this.moneyTransactionService = moneyTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("Index", await readerService.GetAllReaders());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("Create", new CreateReaderModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel(CreateReaderModel model)
        {
            Reader reader = new Reader()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Passport = model.Passport,
            };

            if (reader.Id == 0)
            {
                await readerService.CreateReader(reader);
            }
            else
            {
                await readerService.UpdateReader(reader);
            }

            return RedirectToAction("Info", new { id = reader.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Change(int id)
        {
            Reader reader = await readerService.GetReaderById(id);
            CreateReaderModel model = new CreateReaderModel()
            {
                Id = reader.Id,
                Name = reader.Name,
                Email = reader.Email,
                Passport = reader.Passport,
            };
            return View("Create", model);
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Reader reader = await readerService.GetReaderById(id);
            InfoReaderModel model = new InfoReaderModel()
            {
                Reader = reader,
                BookCheckoutsCurrent = reader.BookCheckouts.Where(e => e.DateBookReturned == null),
                BookCheckoutsHistory = reader.BookCheckouts.Where(e => e.DateBookReturned != null),
            };
            return View("Info", model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await readerService.DeleteReader(id);
            }
            catch (Exception) { } // повторное удаление
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GiveBooks(int readerId)
        {
            GetBooksModel model = new GetBooksModel()
            {
                Reader = await readerService.GetReaderById(readerId),
                AvailableBooks = (await bookService.GetAvailableBooks()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
            };
            return View("GiveBooks", model);
        }

        [HttpPost]
        public async Task<IActionResult> GiveBooks(GetBooksModel model)
        {
            DateTime dateStart = DateTime.Today;
            DateTime dateFinish = dateStart.AddMonths(3);

            foreach(int bookId in model.SelectedBooksId)
            {
                Book book = await bookService.GetBookById(bookId);
                ICollection<BookCopy> availableBookCopies = await bookCopyService.GetAvailableCopiesByBookId(bookId);
                if (availableBookCopies.Count > 0)
                {
                    BookCopy bookCopy = availableBookCopies.ElementAt(0);
                    BookCheckout bookCheckout = new BookCheckout()
                    {
                        BookCopyId = bookCopy.Id,
                        ReaderId = model.Reader.Id,
                        DateStart = dateStart,
                        DateFinish = dateFinish,
                        DateBookReturned = null,
                        OverdueFine = Math.Max(5, (int)(book.Price * 0.01))
                    };
                    bookCopy.BookStatusId = 2;
                    bookCopy.ReaderId = model.Reader.Id;
                    await bookCopyService.UpdateBookCopy(bookCopy);
                    await bookCheckoutService.AddBookCheckout(bookCheckout);
                }
            }
            return RedirectToAction("Info", new { id = model.Reader.Id});
        }


        [HttpGet]
        public async Task<IActionResult> TakeBooks(int readerId)
        {
            Reader reader = await readerService.GetReaderById(readerId);
            ReturnBooksModel model = new ReturnBooksModel()
            {
                Reader = reader,
                AvailableBookCheckouts = reader.BookCheckouts.Where(e => e.DateBookReturned == null).Select(e => new SelectListItem() 
                { 
                    Value = e.Id.ToString(), 
                    Text = e.BookCopy.Book.Name + "   "+ ((DateTime.Now - e.DateFinish).Days > 0 ? $"Штраф: {(DateTime.Now - e.DateFinish).Days * e.OverdueFine} р." : "")
                }),
            };
            return View("TakeBooks", model);
        }

        [HttpPost]
        public async Task<IActionResult> TakeBooks(ReturnBooksModel model)
        {
            DateTime today = DateTime.Today;
            foreach(int bookCheckoutId in model.SelectedBookCheckoutsId)
            {
                BookCheckout bookCheckout = await bookCheckoutService.GetBookCheckoutById(bookCheckoutId);
                bookCheckout.DateBookReturned = today;
                await bookCheckoutService.UpdateBookCheckout(bookCheckout);

                BookCopy bookCopy = bookCheckout.BookCopy;
                bookCopy.ReaderId = null;
                bookCopy.BookStatusId = 1;
                await bookCopyService.UpdateBookCopy(bookCopy);
                
                if (today > bookCheckout.DateFinish)
                {
                    int overdueFine = (today - bookCheckout.DateFinish).Days * bookCheckout.OverdueFine;
                    MoneyTransaction moneyTransaction = new MoneyTransaction()
                    {
                        MoneyTransactionTypeId = 2,
                        ReaderId = model.Reader.Id,
                        Date = today,
                        BookCopyId = bookCopy.Id,
                        AmountOfMoney = overdueFine,
                    };
                    await moneyTransactionService.AddMoneyTransaction(moneyTransaction);
                }
            }
            return RedirectToAction("Info", new { id = model.Reader.Id});
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerifyPassport(string passport, int id)
        {
            IEnumerable<int> readersId = (await readerService.GetReadersByPassport(passport)).Select(r => r.Id);
            return Json(readersId.Count() == 0 || readersId.Contains(id));
        }
    }
}
