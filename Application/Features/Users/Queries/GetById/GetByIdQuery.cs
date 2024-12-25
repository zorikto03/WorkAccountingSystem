using Domain.Common;
using Domain.Entities.Base;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public record GetByIdQuery(Guid Id) : IRequest<Result<User>>;
