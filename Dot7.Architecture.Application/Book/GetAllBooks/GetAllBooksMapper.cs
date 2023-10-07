using AutoMapper;

namespace Dot7.Architecture.Application.Books.GetAllBooks
{
    public class GetAllBooksMapper : Profile
    {
        public GetAllBooksMapper()
        {
            CreateMap<Domain.Entities.Book, GetAllBooksResponse>();
        }
    }
}
