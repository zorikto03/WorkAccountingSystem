using Domain.Common;
using MediatR;

namespace Application.Features.Users.Commands;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Login,
    string Password,
    int SexId ) : IRequest<Result>;
