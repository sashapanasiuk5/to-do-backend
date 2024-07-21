namespace Core.DTO.Task;

public class CreateOrModifyTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public int StatusId { get; set; }

}