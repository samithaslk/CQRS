using System;
using System.Collections.Generic;
using Dot7.Architecture.Application.Books.GetAllBooks;
using Dot7.Architecture.Domain.Entities;

namespace Dot7.Architecture.Application.Contracts
{
    public interface IBookRepositiry: IRepository<Domain.Entities.Book>
    {
        public List<Domain.Entities.Book> GetAllBooks(bool trackChanges);
        public void SaveBook();
    }
}
