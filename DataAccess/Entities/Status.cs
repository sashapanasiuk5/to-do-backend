using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Status
{
    [Key] public int Id { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }

    public List<Task> Tasks = new ();
}