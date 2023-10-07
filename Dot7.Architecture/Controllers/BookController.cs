using Dot7.Architecture.Application.Book.CreateBook;
using Dot7.Architecture.Application.Books.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dot7.Architecture.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllBooksRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateBookRequest payload)
        {
            var newlyCreateItemId = await _mediator.Send(payload);
            return Ok(newlyCreateItemId);
        }
    }
}
