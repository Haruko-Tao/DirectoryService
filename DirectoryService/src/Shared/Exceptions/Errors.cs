using System.Collections;


namespace Shared.Exceptions;

public class Errors : IEnumerable<Error>
{
    private readonly List<Error> _errors;

    public Errors(IEnumerable<Error> errors)
    {
        _errors = errors.ToList();
    }

    public Errors(Error error)
    {
        _errors = new List<Error> { error };
    }

    public IEnumerator<Error> GetEnumerator() => _errors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public static implicit operator Errors(Error error) => new(error);

    public static implicit operator Errors(List<Error> errors) => new(errors);

    public static implicit operator Errors(Error[] errors) => new(errors);
}