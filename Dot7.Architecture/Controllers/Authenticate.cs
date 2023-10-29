using Dot7.Architecture.Application.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dot7.Architecture.Api.Controllers
{
    public class Authenticate : ControllerBase
    {
        private readonly IMediator _mediator;
        public Authenticate(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateGuest([FromBody] GetAuthenticateRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
