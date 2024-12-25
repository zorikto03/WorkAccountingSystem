using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
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

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send( query );

            if ( result.IsFailure )
                return Conflict( result );

            var users = new List<UserVm>();
            result.Value.ForEach( x =>
            {
                var vm = UserVmMapper.EntityToVm( x );
                users.Add( vm );
            } );

            return Ok( new UsersListVm() { Users = users } );
        }

        /// <summary>
        /// get user by identifier GUID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetById( Guid id )
        {
            var query = new GetByIdQuery(id);
            var result = await _mediator.Send( query );

            if ( result.IsFailure )
                return Conflict( result );

            var vm = UserVmMapper.EntityToVm( result.Value );

            return Ok( vm );
        }
    }
}
