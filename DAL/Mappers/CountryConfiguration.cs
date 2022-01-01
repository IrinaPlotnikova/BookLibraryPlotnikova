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
    class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(100);

            builder.HasMany(c => c.Publishers)
                .WithOne(p => p.Country)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Authors)
                .WithOne(a => a.Country)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
