using AutoMapper;
using Dot7.Architecture.Application.Book.CreateBook;
using Dot7.Architecture.Application.Books.GetAllBooks;
using Dot7.Architecture.Application.Context;
using Dot7.Architecture.Application.Contracts;
using MediatR;

namespace Dot7.Architecture.Application.Books.CreateBeach
{
    public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, int>
    {
 
        private readonly IMapper _mapper;
        private readonly IBookRepositiry _bookRepository;
        public CreateBookRequestHandler(IBookRepositiry bookRepository,
        IMapper mapper)
        { 
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var response = new  GetAllBooksResponse();

            var newBook = _mapper.Map<Domain.Entities.Book>(request);

            _bookRepository.Create(newBook);

            _bookRepository.SaveBook();

            response.Id = newBook.Id;

            return response.Id;
        }
    }
}
