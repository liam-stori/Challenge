namespace App.Shared.Results;

public interface IResult
{
    bool IsSuccess { get; }
    bool IsWarning { get; }
    bool IsFailure { get; }
    string ErrorMessage { get; }
    int StatusCode { get; }
}
