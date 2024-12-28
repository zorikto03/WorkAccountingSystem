using Domain.Common;
using MediatR;
using Persistance.Interfaces;

namespace Application.Common.Behaviours;

public class UnitOfWorkPipelineBehaviour<TRequest, TResponce> 
    : IPipelineBehavior<TRequest, TResponce> 
    where TResponce : Result
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkPipelineBehaviour(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponce> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponce> next,
        CancellationToken cancellationToken )
    {
        var responce = await next();
        if ( responce.IsSuccess )
        {
            await _unitOfWork.SaveChangesAsync( cancellationToken );
        }
        return responce;
    }
}
