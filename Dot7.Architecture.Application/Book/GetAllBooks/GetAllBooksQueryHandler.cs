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
        private readonly IMyDbContext _myWorldDbContext;
        private readonly IMapper _mapper;
        public GetAllBooksQueryHandler(IMyDbContext myWorldDbContext,
        IMapper mapper)
        {
            _myWorldDbContext = myWorldDbContext;
            _mapper = mapper;
        }
        public Task<List<GetAllBooksResponse>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            return _myWorldDbContext.Book.ProjectTo<GetAllBooksResponse>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}
