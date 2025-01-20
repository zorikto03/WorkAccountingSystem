using Application.Features.Users.Commands;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.WebApi.Controllers.Users.Models;

namespace Portal.WebApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Create user api method
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var command = _mapper.Map<CreateUserCommand>(dto);

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
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery();
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return Conflict(result);

            var users = new List<UserVm>();
            result.Value.ForEach(x =>
            {
                var vm = _mapper.Map<UserVm>(x);
                users.Add(vm);
            });

            return Ok(new UsersListVm() { Users = users });
        }

        /// <summary>
        /// get user by identifier GUID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        //[Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return Conflict(result);

            var vm = _mapper.Map<UserVm>(result.Value);

            return Ok(vm);
        }
    }
}
