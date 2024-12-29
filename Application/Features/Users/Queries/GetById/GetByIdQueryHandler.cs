using Domain.Common;
using Domain.Entities.Base;
using MediatR;
using Persistance.Interfaces;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Result<User>>
{
    private readonly IUserRepository _userRepository;

    public GetByIdQueryHandler( IUserRepository userRepository ) => 
        _userRepository = userRepository;

    public async Task<Result<User>> Handle(
        GetByIdQuery request,
        CancellationToken cancellationToken )
    {
        var user = await _userRepository.GetByIdAsync(
            request.Id,
            cancellationToken );

        if ( user is null )
            return Result.Failure<User>( 
                DomainError.NotFound( nameof( User ), 
                request.Id.ToString() ) );

        return user;
    }
}
