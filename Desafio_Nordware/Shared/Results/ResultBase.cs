namespace App.Shared.Results;

public abstract class ResultBase : IResult
{
    public bool IsSuccess { get; protected set; }
    public bool IsWarning { get; protected set; }
    public bool IsFailure => !IsSuccess && !IsWarning;
    public string ErrorMessage { get; protected set; }
    public int StatusCode { get; }

    protected ResultBase(int statusCode,
        string errorMessage)
    {
        StatusCode = statusCode;

        if (StatusCode >= 100 && StatusCode < 400)
            IsSuccess = true;

        if (StatusCode >= 400 && StatusCode < 500)
            IsWarning = true;

        ErrorMessage = errorMessage;
    }
}
