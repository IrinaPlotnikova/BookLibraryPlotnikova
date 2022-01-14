using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using BLL.Interfaces;
using BLL.Services;
using DAL.Repositories;
using Domain.RepositoryInterfaces;
using Domain.Entities;

namespace BookLibraryPlotnikova
{ 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var connectionString = Configuration.GetConnectionString("LibraryContext");
            services.AddDbContext<LibraryContext>(ops => ops.UseNpgsql(connectionString));

            services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<IRepository<Publisher>, PublisherRepository>();
            services.AddScoped<IPublisherService, PublisherService>();

            services.AddScoped<IRepository<Author>, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IRepository<Reader>, ReaderRepository>();
            services.AddScoped<IReaderService, ReaderService>();

            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IRepository<Genre>, GenreRepository>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<IRepository<BookCopy>, BookCopyRepository>();
            services.AddScoped<IBookCopyService, BookCopyService>();

            services.AddScoped<IRepository<MoneyTransaction>, MoneyTransactionRepository>();
            services.AddScoped<IMoneyTransactionService, MoneyTransactionService>();

            services.AddScoped<IRepository<BookCheckout>, BookCheckoutRepository>();
            services.AddScoped<IBookCheckoutService, BookCheckoutService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
