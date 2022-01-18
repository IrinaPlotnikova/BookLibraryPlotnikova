using BLL.Filters;
using BLL.Interfaces;
using ClosedXML.Excel;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.Services
{
    public class BookCheckoutService : IBookCheckoutService
    {
        private readonly IRepository<BookCheckout>  repository;

        public BookCheckoutService(IRepository<BookCheckout> repository)
        {
            this.repository = repository;
        }

        public Task CreateBookCheckout(BookCheckout bookCheckout)
        {
            return repository.CreateAsync(bookCheckout);
        }

        public Task UpdateBookCheckout(BookCheckout bookCheckout)
        {
            return repository.UpdateItemAsync(bookCheckout);
        }

        public Task<ICollection<BookCheckout>> GetBookCheckoutsByReaderId(int readerId)
        {
            Expression<Func<BookCheckout, bool>> expression = e => e.ReaderId == readerId;
            return repository.GetByFilterAsync(expression);
        }

        public Task<BookCheckout> GetBookCheckoutById(int bookCheckoutId)
        {
            return repository.GetByIdAsync(bookCheckoutId);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }

        public Task CreateBookCheckouts(IEnumerable<BookCheckout> bookCheckouts)
        {
            return repository.CreateRangeAsync(bookCheckouts);
        }

        public async Task<MemoryStream> SaveStatisticsAsXlsxFileToMemoryStream(DateFilter filter)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add();
            var currentRow = 1;

            string[] rowTitles = new string[] { "Дата", "Тип операции", "Книга", "Читатель"};
            for (int i = 0; i < rowTitles.Length; i++)
            {
                worksheet.Cell(currentRow, i + 1).Value = rowTitles[i];
            }

            var checkoutsToReaders = (await GetBookCheckoutsToReadersByDates(filter))
                .Select(e => new {Date = e.DateStart, BookName = e.BookCopy?.Book?.Name, ReaderName = e.Reader?.Name, Type = "Выдача", });
            var checkoutsFromReaders = (await GetBookCheckoutsFromReadersByDates(filter))
                .Select(e => new {Date = e.DateBookReturned.Value, BookName = e.BookCopy?.Book?.Name, ReaderName = e.Reader?.Name, Type = "Приём", });

            var checkouts = checkoutsToReaders.ToList();
            checkouts.AddRange(checkoutsFromReaders);
            checkouts = checkouts.OrderBy(e => e.Date).ToList();
            foreach (var item in checkouts)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Style.NumberFormat.Format = "yyyy.mm.dd";
                worksheet.Cell(currentRow, 1).Value = item.Date;
                worksheet.Cell(currentRow, 2).Value = item.Type;
                worksheet.Cell(currentRow, 3).Value = item.BookName;
                worksheet.Cell(currentRow, 4).Value = item.ReaderName;
            }

            worksheet.Columns().AdjustToContents();
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream;
        }

        private Task<ICollection<BookCheckout>> GetBookCheckoutsToReadersByDates(DateFilter filter)
        {
            Expression<Func<BookCheckout, bool>> expression = e => filter.FirstDate <= e.DateStart && e.DateStart <= filter.LastDate;
            return repository.GetByFilterAsync(expression);
        }

        private Task<ICollection<BookCheckout>> GetBookCheckoutsFromReadersByDates(DateFilter filter)
        {
            Expression<Func<BookCheckout, bool>> expression = e => e.DateBookReturned != null &&
                filter.FirstDate <= e.DateBookReturned && e.DateBookReturned <= filter.LastDate;
            return repository.GetByFilterAsync(expression);
        }
    }
}
