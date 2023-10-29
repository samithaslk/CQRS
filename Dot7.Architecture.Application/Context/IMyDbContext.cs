using Dot7.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dot7.Architecture.Application.Context
{
    public interface IMyDbContext
    {
        DbSet<Domain.Entities.Book> Book { get; }
        DbSet<Domain.Entities.User> LibraryUser { get; }
        Task<int> SaveToDbAsync();
    }
}
