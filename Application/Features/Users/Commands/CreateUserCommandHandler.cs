using Domain.Common;
using Domain.Entities.Base;
using MediatR;
using Persistance.Interfaces;

namespace Application.Features.Users.Commands;

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle( CreateUserCommand request, CancellationToken cancellationToken )
    {
        var userResult = User.Create(
            request.FirstName,
            request.LastName,
            request.Login,
            request.Password,
            request.Sex);
        
        if (userResult.IsFailure)
        {
            return Result.Failure( userResult.Error ) ;
        }

        await _userRepository.Add( userResult.Value );

        return Result.Success();
    }
}
