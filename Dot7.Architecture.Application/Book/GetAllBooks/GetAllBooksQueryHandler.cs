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

namespace Dot7.Architecture.Application.Books.GetAllBeaches
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksRequest, List<GetAllBooksResponse>>
    {
        private readonly IMyDbContext _myDbContext;
        private readonly IMapper _mapper;
        public GetAllBooksQueryHandler(IMyDbContext myDbContext,
        IMapper mapper)
        {
            _myDbContext = myDbContext;
            _mapper = mapper;
        }
        public Task<List<GetAllBooksResponse>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            return _myDbContext.Book.ProjectTo<GetAllBooksResponse>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}
