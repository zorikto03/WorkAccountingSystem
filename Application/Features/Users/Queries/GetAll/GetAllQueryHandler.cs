using Domain.Common;
using Domain.Entities.Base;
using MediatR;
using Persistance.Interfaces;

namespace Application.Features.Users.Queries.GetAll;


public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Result<List<User>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllQueryHandler( IUserRepository userRepository )
    {
        _userRepository = userRepository;
    }

    public async Task<Result<List<User>>> Handle(
        GetAllQuery request,
        CancellationToken cancellationToken )
    {
        var users = await _userRepository.GetAllAsync( cancellationToken );
        if ( users is null )
            return Result.Failure<List<User>>( DomainError.IsNull( nameof( List<User> ) ) );

        return users;
    }
}
