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
    class BookCopyConfiguration : IEntityTypeConfiguration<BookCopy>
    {
        public void Configure(EntityTypeBuilder<BookCopy> builder)
        {
            builder.HasKey(bc => bc.Id);

            builder.HasOne(bc => bc.Book)
                .WithMany(bc => bc.BookCopies)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(bc => bc.Book)
                .WithMany(bs => bs.BookCopies)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(bc => bc.Reader)
                .WithMany(r => r.BookCopies)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
