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
    class BookStatusConfiguration : IEntityTypeConfiguration<BookStatus>
    {
        public void Configure(EntityTypeBuilder<BookStatus> builder)
        {
            builder.HasKey(bs => bs.Id);

            builder.Property(bs => bs.Name).HasMaxLength(100);

            builder.HasMany(bs => bs.BookCopies)
                .WithOne(bc => bc.BookStatus)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
