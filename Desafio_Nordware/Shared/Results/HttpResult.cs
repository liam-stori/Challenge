namespace App.Shared.Results;

public class HttpResult : ResultBase
{

    public HttpResult(int statusCode, string errorMessage)
        : base(statusCode, errorMessage)
    {
    }

    public static HttpResult Success(int statusCode)
        => new(statusCode, string.Empty);

    public static HttpResult Warning(int statusCode, string errorMessage)
        => new(statusCode, errorMessage);

    public static HttpResult Failure(int statusCode, string errorMessage)
        => new(statusCode, errorMessage);
}
