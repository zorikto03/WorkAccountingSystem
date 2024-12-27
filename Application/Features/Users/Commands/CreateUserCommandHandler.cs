using Domain.Common;
using Domain.Entities.Base;
using MediatR;
using Persistance.Interfaces;

namespace Application.Features.Users.Commands;

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly ISexEnumRepository _sexEnumRepository;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        ISexEnumRepository sexEnumRepository )
    {
        _userRepository = userRepository;
        _sexEnumRepository = sexEnumRepository;
    }

    public async Task<Result> Handle( CreateUserCommand request, CancellationToken cancellationToken )
    {
        var sex = await _sexEnumRepository.GetById( request.SexId, cancellationToken );
        if (sex is null )
        {
            return Result.Failure(DomainError.NotFound(typeof(SexEnum).Name, request.SexId.ToString()));
        }

        var userResult = User.Create(
            request.FirstName,
            request.LastName,
            request.Login,
            request.Password,
            sex.Id);
        
        if (userResult.IsFailure)
        {
            return Result.Failure( userResult.Error ) ;
        }

        await _userRepository.Add( userResult.Value );

        return Result.Success();
    }
}
