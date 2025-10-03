namespace Shared.Exceptions;

public static class GeneralErrors
{
    public static Error Validation(string code, string message) =>
        new(code, message, ErrorType.VALIDATION);

    public static Error NotFound(string code, string message) =>
        new(code, message, ErrorType.NOT_FOUND);

    public static Error Conflict(string code, string message) =>
        new(code, message, ErrorType.CONFLICT);

    public static Error Failure(string code, string message) =>
        new(code, message, ErrorType.FAILURE);
}