using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    class MoneyTransactionConfiguration : IEntityTypeConfiguration<MoneyTransaction>
    {
        public void Configure(EntityTypeBuilder<MoneyTransaction> builder)
        {
            builder.HasKey(mt => mt.Id);

            builder.HasOne(mt => mt.BookCopy)
                .WithMany(bc => bc.MoneyTransactions)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(mt => mt.Reader)
                .WithMany(r => r.MoneyTransactions)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(mt => mt.MoneyTransactionType)
                .WithMany(mtt => mtt.MoneyTransactions)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
