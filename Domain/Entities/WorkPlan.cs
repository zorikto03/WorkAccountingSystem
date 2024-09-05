using Domain.Common;
using Domain.Entities.Base;

namespace Domain.Entities;

public class WorkPlan : Memo
{
    public List<Practice> Practices { get; private set; } = [];

    public Almanac Almanac { get; private set; }


    public WorkPlan( Guid id, string title, Almanac almanac ) : base(id, title)
    {
        Almanac = almanac;
    }

    public Result AddPractice(Practice practice )
    {
        if ( Practices.Contains( practice ) )
        {
            return Result.Failure( DomainError.EntityContains( nameof( practice ), nameof( Practices ) ) );
        }

        Practices.Add( practice );
        return Result.Success();
    }
}
