using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.Logout;

internal class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result>
{
    //private readonly 
    public LogoutCommandHandler()
    {
        
    }

    public Task<Result> Handle( LogoutCommand request, CancellationToken cancellationToken )
    {
        throw new NotImplementedException();
    }
}
