using Domain.Common;
using Domain.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public static int MaxNameLength = 20;
        public static int MinNameLength = 2;

        private Name( string firstName, string lastName ) =>
            (FirstName, LastName) = (firstName, lastName);


        public string FirstName { get; init; }
        public string LastName { get; init; }


        public static Result<Name> Create(string firstName, string lastName )
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty( lastName ) )
            {
                return Result.Failure<Name>( DomainError.IsEmpty( nameof( firstName ) ) );
            }

            return Result.Success(new Name( firstName, lastName ));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
