using AutoMapper;
using Dot7.Architecture.Application.Book.CreateBook;
using Dot7.Architecture.Application.Context;
using MediatR;

namespace Dot7.Architecture.Application.Books.CreateBeach
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookRequest, int>
    {
        private readonly IMyDbContext _myWorldDbContext;
        private readonly IMapper _mapper;
        public CreateBookCommandHandler(IMyDbContext myWorldDbContext,
        IMapper mapper)
        {
            _myWorldDbContext = myWorldDbContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var newBook = _mapper.Map<Domain.Entities.Book>(request);
            _myWorldDbContext.Book.Add(newBook);
            await _myWorldDbContext.SaveToDbAsync();
            return newBook.Id;
        }
    }
}
