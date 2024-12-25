using Domain.Common;
using Domain.Entities.Base;
using MediatR;

namespace Application.Features.Users.Queries.GetAll;


public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Result<List<User>>>
{
    public GetAllQueryHandler()
    {
        //todo
    }

    public Task<Result<List<User>>> Handle( GetAllQuery request, CancellationToken cancellationToken )
    {
        throw new NotImplementedException();
    }
}
