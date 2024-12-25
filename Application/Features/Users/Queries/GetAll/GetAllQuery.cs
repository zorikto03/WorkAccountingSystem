using Domain.Common;
using Domain.Entities.Base;
using MediatR;

namespace Application.Features.Users.Queries.GetAll;

public record GetAllQuery : IRequest<Result<List<User>>>;
