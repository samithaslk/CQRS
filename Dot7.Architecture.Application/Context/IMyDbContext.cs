using Dot7.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dot7.Architecture.Application.Context
{
    public interface IMyDbContext
    {
        DbSet<Domain.Entities.Book> Book { get; }

        Task<int> SaveToDbAsync();
    }
}
