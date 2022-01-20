using DAL.Mappers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCheckout> BookCheckouts { get; set; }

        public DbSet<BookCopy> BookCopies { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MoneyTransaction> MoneyTransactions { get; set; }

        public DbSet<MoneyTransactionType> MoneyTransactionTypes { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookCheckoutConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookCopyConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyTransactionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            modelBuilder.ApplyConfiguration(new ReaderConfiguration());
        }
    }
}
