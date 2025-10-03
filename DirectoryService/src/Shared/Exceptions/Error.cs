namespace Shared.Exceptions;

public record Error
{
    public string Code { get; }
    public string Message { get; }
    public ErrorType Type { get;  }
    public string? InvalidField { get; }

    public Error(string code, string message, ErrorType type, string? invalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidField = invalidField;
    }
    
    public Errors ToErrors() => this;

}

public enum ErrorType
{
    /// <summary>
    /// Ошибка с валидацией.
    /// </summary>
    VALIDATION,
    /// <summary>
    /// Ошибка ничего не найдено.
    /// </summary>
    NOT_FOUND,
    /// <summary>
    /// Ошибка сервера.
    /// </summary>
    FAILURE,
    /// <summary>
    /// Ошибка конфликт.
    /// </summary>
    CONFLICT,
}