using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Task
{
    [Key]
    public int Id {get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public Status Status { get; set; }

}