using System.Runtime.InteropServices;

namespace Domain.Common;

public sealed class DomainError
{
    public static readonly Error None = new Error( string.Empty, string.Empty );

    public static readonly Func<string, Guid, Error> NotFound = (type, id) => new Error ( 
        $"{type}.NotFound.", 
        $"{type} with identifier {id} not be found." );

    public static readonly Func<string, Error> IsNull = ( type ) => new Error(
        $"{type}.IsNull.",
        $"{type} cannot be null." );

    public static readonly Func<string, Error> IsEmpty = (type) => new Error(
        $"{type}.IsEmpty.",
        $"{type} cannot be empty." );

    public static readonly Func<string, Error> Invalid = param => new Error(
        $"{param}.IsEmpty.",
        $"{param} is invalid." );

    public static readonly Func<string, string, Error> EntityContains = (entityName, collectionName) => new(
        $"{collectionName}.EntityContains.",
        $"{collectionName} collection already contains entity {entityName}." );

    public static class ValueObject
    {
        public static readonly Func<string, Error> TooLong = name => new(
            "ValueObject.TooLong",
            $"{name} value length is too long");

        public static readonly Func<string, Error> IsEmpty = name => new(
            "ValueObject.Value",
            $"{name} value is empty or null" );
    }
}
