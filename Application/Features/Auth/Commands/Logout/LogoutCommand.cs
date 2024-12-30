using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Commands.Logout;

public record LogoutCommand : IRequest<Result>;
