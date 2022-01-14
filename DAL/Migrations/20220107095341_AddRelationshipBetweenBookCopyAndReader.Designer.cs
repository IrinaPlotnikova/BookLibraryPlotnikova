﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20220107095341_AddRelationshipBetweenBookCopyAndReader")]
    partial class AddRelationshipBetweenBookCopyAndReader
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("integer");

                    b.Property<int>("BooksId")
                        .HasColumnType("integer");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ShortName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("integer");

                    b.Property<int>("PublishmentYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Domain.Entities.BookCheckout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BookCopyId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateBookReturned")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateFinish")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LostBookFine")
                        .HasColumnType("integer");

                    b.Property<int>("OverdueFine")
                        .HasColumnType("integer");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("ReaderId");

                    b.ToTable("BookCheckouts");
                });

            modelBuilder.Entity("Domain.Entities.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("integer");

                    b.Property<int?>("BookStatusId")
                        .HasColumnType("integer");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BookStatusId");

                    b.HasIndex("ReaderId");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("Domain.Entities.BookStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("BookStatuses");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Domain.Entities.MoneyTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AmountOfMoney")
                        .HasColumnType("integer");

                    b.Property<int?>("BookCopyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("MoneyTransactionTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("MoneyTransactionTypeId");

                    b.HasIndex("ReaderId");

                    b.ToTable("MoneyTransactions");
                });

            modelBuilder.Entity("Domain.Entities.MoneyTransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("MoneyTransactionTypes");
                });

            modelBuilder.Entity("Domain.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Domain.Entities.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("LibraryCard")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Passport")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Domain.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("Authors")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.HasOne("Domain.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Domain.Entities.BookCheckout", b =>
                {
                    b.HasOne("Domain.Entities.BookCopy", "BookCopy")
                        .WithMany("BookCheckouts")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Entities.Reader", "Reader")
                        .WithMany("BookCheckouts")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("BookCopy");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Domain.Entities.BookCopy", b =>
                {
                    b.HasOne("Domain.Entities.Book", "Book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.Entities.BookStatus", "BookStatus")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookStatusId");

                    b.HasOne("Domain.Entities.Reader", "Reader")
                        .WithMany("BookCopies")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Book");

                    b.Navigation("BookStatus");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Domain.Entities.MoneyTransaction", b =>
                {
                    b.HasOne("Domain.Entities.BookCopy", "BookCopy")
                        .WithMany("MoneyTransactions")
                        .HasForeignKey("BookCopyId");

                    b.HasOne("Domain.Entities.MoneyTransactionType", "MoneyTransactionType")
                        .WithMany("MoneyTransactions")
                        .HasForeignKey("MoneyTransactionTypeId");

                    b.HasOne("Domain.Entities.Reader", "Reader")
                        .WithMany("MoneyTransactions")
                        .HasForeignKey("ReaderId");

                    b.Navigation("BookCopy");

                    b.Navigation("MoneyTransactionType");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Domain.Entities.Publisher", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("Publishers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Navigation("BookCopies");
                });

            modelBuilder.Entity("Domain.Entities.BookCopy", b =>
                {
                    b.Navigation("BookCheckouts");

                    b.Navigation("MoneyTransactions");
                });

            modelBuilder.Entity("Domain.Entities.BookStatus", b =>
                {
                    b.Navigation("BookCopies");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("Domain.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.Entities.MoneyTransactionType", b =>
                {
                    b.Navigation("MoneyTransactions");
                });

            modelBuilder.Entity("Domain.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.Entities.Reader", b =>
                {
                    b.Navigation("BookCheckouts");

                    b.Navigation("BookCopies");

                    b.Navigation("MoneyTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
