using Dot7.Architecture.Application.Context;
using Dot7.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dot7.Architecture.Infrastructure.Context
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Book { get; set; }
        public async Task<int> SaveToDbAsync()
        {
            return await SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>(b =>
            //{
            //    b.HasKey(e => e.Id);
            //    b.Property(e => e.Id).ValueGeneratedOnAdd();
            //});

          
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).UseIdentityColumn(10000000,1); 
                b.HasData(
                new Book { Id=4, Author = "Maria Hoey and Peter Hoey", Isbn = "978-1-60309-502-0", Title = "Animal Stories" },
                new Book { Id =5,Author = "Emilia McKenzie", Isbn = "978-1-60309-527-3", Title = "But You Have Friends" }
                );
            });

           //modelBuilder.Entity<Book>().HasData(
           //     new Book { Id=1,Author = "Maria Hoey and Peter Hoey", Isbn = "978-1-60309-502-0", Title = "Animal Stories" },
           //     new Book { Id = 2, Author = "Emilia McKenzie", Isbn = "978-1-60309-527-3", Title = "But You Have Friends" }
           //     );
        }
    }
}
