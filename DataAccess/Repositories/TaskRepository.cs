using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = DataAccess.Entities.Task;
namespace DataAccess.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly AppDbContext _dbContext;

    public TaskRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Task> GetAll()
    {
        return _dbContext.Tasks.Include(t => t.Status).ToList();
    }

    public Task? GetById(int id)
    {
        return _dbContext.Tasks.Include(t => t.Status).SingleOrDefault(t => t.Id == id);
    }

    public void Add(Task task)
    {
        _dbContext.Tasks.Add(task);
    }

    public void Update(Task task)
    {
        _dbContext.Tasks.Update(task);
    }

    public void Delete(Task task)
    {
        _dbContext.Tasks.Remove(task);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}