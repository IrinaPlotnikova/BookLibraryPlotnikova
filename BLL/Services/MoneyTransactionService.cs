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
    public class MoneyTransactionService : IMoneyTransactionService
    {
        private readonly IRepository<MoneyTransaction> repository;

        public MoneyTransactionService(IRepository<MoneyTransaction> repository)
        {
            this.repository = repository;
        }

        public Task CreateMoneyTransaction(MoneyTransaction moneyTransaction)
        {
            return repository.CreateAsync(moneyTransaction);
        }

        public Task<ICollection<MoneyTransaction>> GetTransactionsByDates(DateFilter filter)
        {
            Expression<Func<MoneyTransaction, bool>> expression = e => filter.FirstDate <= e.Date && e.Date <= filter.LastDate;
            return repository.GetByFilterAsync(expression);
        }

        public Task CreateMoneyTransactions(IEnumerable<MoneyTransaction> moneyTransactions)
        {
            return repository.CreateRangeAsync(moneyTransactions);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }

        public async Task<MemoryStream> SaveStatisticsAsXlsxFileToMemoryStream(DateFilter filter)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add();
            var currentRow = 1;

            string[] rowTitles = new string[] { "Дата", "Сумма", "Тип операции", "Книга", "Читатель"};
            for (int i = 0; i < rowTitles.Length; i++)
            {
                worksheet.Cell(currentRow, i + 1).Value = rowTitles[i];
            }

            IEnumerable<MoneyTransaction> transactions = (await GetTransactionsByDates(filter)).OrderBy(e => e.Date);
            foreach (var item in transactions)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Style.NumberFormat.Format = "yyyy.mm.dd";
                worksheet.Cell(currentRow, 1).Value = item.Date;
                worksheet.Cell(currentRow, 2).Value = item.AmountOfMoney;
                worksheet.Cell(currentRow, 3).Value = item.MoneyTransactionType.Name;
                worksheet.Cell(currentRow, 4).Value = item.BookCopy?.Book?.Name;
                worksheet.Cell(currentRow, 5).Value = item.Reader?.Name;
            }

            worksheet.Columns().AdjustToContents();
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream;
        }
    }
}
