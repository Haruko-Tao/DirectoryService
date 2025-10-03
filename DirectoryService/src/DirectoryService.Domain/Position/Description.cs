using CSharpFunctionalExtensions;
using Shared.Exceptions;

namespace DirectoryService.Domain.Position;

public class Description
{
        public string Value { get; }

        public Description(string value)
        {
            Value = value;
        }

        public static Result<Description, Errors> Create(string value)
        {
            var errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(value))
                errors.Add(GeneralErrors.Validation("description", "The description cannot be empty"));
            
            if (errors.Any())
                return Result.Failure<Description, Errors>(new Errors(errors));

            return Result.Success<Description, Errors>(new Description(value));
        }
}

