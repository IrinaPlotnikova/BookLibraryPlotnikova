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
    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FullName).HasMaxLength(100);
            builder.Property(a => a.ShortName).HasMaxLength(30);
        }
    }
}
