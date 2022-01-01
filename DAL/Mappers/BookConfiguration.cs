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
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).HasMaxLength(200);

            builder.HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(b => b.BookCopies)
                .WithOne(bc => bc.Book)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(t => t.ToTable("BookAuthors"));
        }
    }
}
