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
    class MoneyTransactionTypeConfiguration : IEntityTypeConfiguration<MoneyTransactionType>
    {
        public void Configure(EntityTypeBuilder<MoneyTransactionType> builder)
        {
            builder.HasKey(mtt => mtt.Id);

            builder.Property(mtt => mtt.Name).HasMaxLength(100);

            builder.HasMany(mtt => mtt.MoneyTransactions)
                .WithOne(mt => mt.MoneyTransactionType)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
