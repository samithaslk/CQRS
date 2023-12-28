
using Dot7.Architecture.Application.Books.GetAllBooks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Books.GetAllBooks
{
    public class GetAllBooksRequest : IRequest<IEnumerable<GetAllBooksResponse>>
    {
    }
}
