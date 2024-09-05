using Domain.Entities.Base;

namespace Domain.Entities;

/// <summary>
/// It is timeTable. It store work plans list 
/// </summary>
public class Almanac : Base.Base
{
    private User _client { get; set; }
    private User? _employee { get; set; }
    private IEnumerable<WorkPlan> _workPlans { get; set; } = new List<WorkPlan>();

    public Almanac( Guid id,
                   User client,
                   User employee,
                   IEnumerable<WorkPlan> workPlans) : base( id, DateTime.Now, null )
    {
        _workPlans = workPlans;
        _client = client;
        _employee = employee;
    }

    /// <summary>
    /// Client is one of those who can create almanac
    /// </summary>
    public User Author => _client;

    /// <summary>
    /// Client is one of those who can create almanac. Can be is null if almanac was created by client without an observer
    /// </summary>
    public User? Observer => _employee;


}
