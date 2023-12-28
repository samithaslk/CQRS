using Dot7.Architecture.Application.Books.GetAllBooks;
using Dot7.Architecture.Application.Contracts;
using Dot7.Architecture.Domain.Entities;
using Dot7.Architecture.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dot7.Architecture.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Domain.Entities.Book>, IBookRepositiry
    {
        public BookRepository(MyDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public List<Domain.Entities.Book> GetAllBooks(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(c => c.Isbn).ToList();
        }

        public void SaveBook()
        {
            Save();
        }
    }
}
 