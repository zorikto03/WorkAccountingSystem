using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.WebApi.Controllers.Models;

namespace Portal.WebApi.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create user api method
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] CreateUserDto dto)
        {
            var command = CreateUserMapper.DtoToCommand(dto);
            
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return Conflict(result);
            }
            return NoContent();
        }
    }
}
