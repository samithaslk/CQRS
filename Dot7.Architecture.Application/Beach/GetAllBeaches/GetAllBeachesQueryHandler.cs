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

namespace Dot7.Architecture.Application.Beach.GetAllBeaches
{
    public class GetAllBeachesQueryHandler : IRequestHandler<GetAllBeachesRequest, List<GetAllBeachesResponse>>
    {
        private readonly IMyDbContext _myWorldDbContext;
        private readonly IMapper _mapper;
        public GetAllBeachesQueryHandler(IMyDbContext myWorldDbContext,
        IMapper mapper)
        {
            _myWorldDbContext = myWorldDbContext;
            _mapper = mapper;
        }
        public Task<List<GetAllBeachesResponse>> Handle(GetAllBeachesRequest request, CancellationToken cancellationToken)
        {
            return _myWorldDbContext.Beach.ProjectTo<GetAllBeachesResponse>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}
