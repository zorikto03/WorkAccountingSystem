using Domain.Common;
using Domain.Entities.Base;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Result<User>>
{
    //todo

    public GetByIdQueryHandler()
    {
        //todo
    }

    public Task<Result<User>> Handle( GetByIdQuery request, CancellationToken cancellationToken )
    {
        //todo
        throw new NotImplementedException();
    }
}
