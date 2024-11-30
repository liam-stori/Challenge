namespace App.Shared.Results;

public class HttpResultResponse<T> : ResultBase
{
    public T Value { get; }

    public HttpResultResponse(T value, int statusCode, string errorMessage)
        : base(statusCode, errorMessage)
    {
        Value = value;
    }

    public static HttpResultResponse<T> Success(int statusCode, T value)
        => new(value, statusCode, string.Empty);

    public static HttpResultResponse<T> Warning(int statusCode, string errorMessage)
        => new(default!, statusCode, errorMessage);

    public static HttpResultResponse<T> Failure(int statusCode, string errorMessage)
        => new(default!, statusCode, errorMessage);
}