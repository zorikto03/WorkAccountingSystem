using Domain.Common;
using Domain.Entities.Base;
using MediatR;
using Persistance.Interfaces;

namespace Application.Features.Auth.Commands.Login;

internal class LoginCommandHandler : IRequestHandler<LoginCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler( IUserRepository userRepository )
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle( LoginCommand request, CancellationToken cancellationToken )
    {
        var users = await _userRepository.GetAllAsync( cancellationToken );
        var user = users.FirstOrDefault(x=>x.LoginPassword.Login == request.Login);

        if ( user == null ) 
            return Result.Failure(DomainError.NotFound(nameof(User), request.Login));

        if ( user.LoginPassword.Password != request.Password )
            return Result.Failure( DomainError.None );

        return Result.Success();
    }
}
