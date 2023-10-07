using AutoMapper;
using Dot7.Architecture.Application.Book.CreateBook;

namespace Dot7.Architecture.Application.Beach.CreateBeach
{
    public class CreateBookMapper : Profile
    {
        public CreateBookMapper()
        {
            CreateMap<CreateBookRequest, Dot7.Architecture.Domain.Entities.Book>();
        }
    }
}
