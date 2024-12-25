using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Users.Commands;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Login,
    string Password,
    SexEnum Sex ) : IRequest<Result>;
