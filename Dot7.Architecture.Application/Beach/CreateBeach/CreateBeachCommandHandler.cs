using AutoMapper;
using Dot7.Architecture.Application.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Beach.CreateBeach
{
    public class CreateBeachCommandHandler : IRequestHandler<CreateBeachRequest, int>
    {
        private readonly IMyDbContext _myWorldDbContext;
        private readonly IMapper _mapper;
        public CreateBeachCommandHandler(IMyDbContext myWorldDbContext,
        IMapper mapper)
        {
            _myWorldDbContext = myWorldDbContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateBeachRequest request, CancellationToken cancellationToken)
        {
            var newBeach = _mapper.Map<Dot7.Architecture.Domain.Entities.Beach>(request);
            _myWorldDbContext.Beach.Add(newBeach);
            await _myWorldDbContext.SaveToDbAsync();
            return newBeach.Id;
        }
    }
}
