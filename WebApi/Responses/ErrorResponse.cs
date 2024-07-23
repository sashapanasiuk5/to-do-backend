namespace WebApi.Responses;

public class ErrorResponse
{
    public string Error { get; set; }
    public List<string> Details { get; set; }
}