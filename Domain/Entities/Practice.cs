using Domain.Entities.Base;

namespace Domain.Entities;

/// <summary>
/// it is part of any plans
/// </summary>
public class Practice : Memo, IEquatable<Practice>
{
    /// <summary>
    /// Exercises Description
    /// </summary>
    public string Description { get; private set; } = string.Empty;
    /// <summary>
    /// Количество повторений
    /// </summary>
    public int AmountRepetitions { get; set; } = 0;
    /// <summary>
    /// Количество подходов
    /// </summary>
    public int AmountApproaches { get; set;} = 0;

    public IEnumerable<string> ImagePaths { get; private set; } = new List<string>();
    public IEnumerable<string> VideoPaths { get; private set; } = new List<string>();

    public Practice( Guid id, string title ) : base( id, title )
    {
    }

    public bool Equals( Practice? other )
    {
        if ( other == null ) return false;

        return Title.Equals( other.Title )
            && AmountApproaches == other.AmountApproaches
            && AmountRepetitions == other.AmountRepetitions;
    }
}
