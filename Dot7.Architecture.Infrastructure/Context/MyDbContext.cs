using Dot7.Architecture.Application.Context;
using Dot7.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Infrastructure.Context
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        public DbSet<Beach> Beach { get; set; }
        public async Task<int> SaveToDbAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
