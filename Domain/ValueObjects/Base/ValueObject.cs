
namespace Domain.ValueObjects.Base;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    protected static bool EqualOperator(object left, object right)
    {
        if ( left is null || right is null )
            return false;

        return ReferenceEquals( left, right ) || left.Equals(right);
    }

    public override bool Equals(object obj)
    {
        if ( obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual( other.GetEqualityComponents() );
    }

    public static bool operator ==( ValueObject left, ValueObject right )
    {
        return EqualOperator(left, right);
    }

    public static bool operator != ( ValueObject left, ValueObject right )
    {
        return !EqualOperator(left, right);
    }
}
