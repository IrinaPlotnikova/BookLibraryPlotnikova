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
        }
    }
}
