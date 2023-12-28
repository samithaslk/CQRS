using AutoMapper;
using Dot7.Architecture.Application.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dot7.Architecture.Application.Books.GetAllBooks;
using Dot7.Architecture.Application.Contracts;

namespace Dot7.Architecture.Application.Books.GetAllBeaches
{
    public class GetAllBooksRequestHandler : IRequestHandler<GetAllBooksRequest, IEnumerable<GetAllBooksResponse>>
    {
        
        private readonly IMapper _mapper;
        private readonly IBookRepositiry _bookRepository;
        public GetAllBooksRequestHandler(IBookRepositiry bookRepository,
        IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<GetAllBooksResponse>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            var response = new List<GetAllBooksResponse>(); 
            List<Domain.Entities.Book> repo = _bookRepository.GetAllBooks(false);
            _mapper.Map(repo, response);

            return response;


        }
    }
}
