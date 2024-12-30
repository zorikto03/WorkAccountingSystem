using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Logout;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portal.WebApi.Controllers.Auth.Models;

namespace Portal.WebApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync( [FromBody] LoginCommandDto dto )
        {
            var command = _mapper.Map<LoginCommand>( dto );
            var result = await _mediator.Send( command );

            if (result.IsFailure)
                return Conflict( result );

            return NoContent();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            var command = new LogoutCommand();
            var result = await _mediator.Send( command );
            
            if (result.IsFailure)
                return Conflict( result );

            return NoContent();
        }
    }
}
