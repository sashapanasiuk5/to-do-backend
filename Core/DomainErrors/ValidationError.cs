using FluentResults;
using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace Core.DomainErrors;

public class ValidationError: IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }

    public ValidationError(List<ValidationFailure> errors)
    {
        Message = "Validation error";
        Reasons = new List<IError>();
        foreach (var error in errors)
        {
            Reasons.Add(new Error(error.ErrorMessage));
        }
    }
}