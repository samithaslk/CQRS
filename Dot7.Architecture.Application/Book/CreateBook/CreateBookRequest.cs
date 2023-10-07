using MediatR;

namespace Dot7.Architecture.Application.Book.CreateBook
{
    public class CreateBookRequest : IRequest<int>
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
    }
}
