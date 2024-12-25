using MediatR;

namespace Application.Features.Users.Queries.GetAll;


public class GetAllQueryHandler : IRequestHandler<GetAllQuery>
{
    public GetAllQueryHandler()
    {
        //todo
    }

    public Task Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
