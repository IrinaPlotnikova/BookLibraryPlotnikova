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
    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FullName).HasMaxLength(100);
            builder.Property(a => a.ShortName).HasMaxLength(30);

            builder.HasOne(a => a.Country)
                .WithMany(c => c.Authors)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .UsingEntity(t => t.ToTable("BookAuthors"));
        }
    }
}
