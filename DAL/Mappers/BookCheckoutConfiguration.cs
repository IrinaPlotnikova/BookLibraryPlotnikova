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
    class BookCheckoutConfiguration : IEntityTypeConfiguration<BookCheckout>
    {
        public void Configure(EntityTypeBuilder<BookCheckout> builder)
        {
            builder.HasKey(bc => bc.Id);

            builder.HasOne(bc => bc.BookCopy)
                .WithMany(copy => copy.BookCheckouts)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(bc => bc.Reader)
                .WithMany(r => r.BookCheckouts)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(bc => bc.MoneyTransactions)
                .WithOne(mt => mt.BookCheckout)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
