﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    class ReaderConfiguration : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(b => b.Name).HasMaxLength(200);
            builder.Property(b => b.LibraryCard).HasMaxLength(200);
            builder.Property(b => b.Passport).HasMaxLength(200);
            builder.Property(b => b.Email).HasMaxLength(200);

            builder.HasMany(r => r.BookCheckouts)
                .WithOne(bc => bc.Reader)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
