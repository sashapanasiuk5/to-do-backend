using FluentResults;

namespace Core.DomainErrors;

public class NotFoundError: IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }


    public NotFoundError(Type entity, int id)
    {
        Message = $"{entity.Name} with id {id} was not found";
    }
}