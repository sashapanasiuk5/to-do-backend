namespace DataAccess.Repositories.Interfaces;
using Task = Entities.Task;
public interface ITaskRepository
{
    List<Task> GetAll();

    Task? GetById(int id);

    void Add(Task task);

    void Update(Task task);

    void Delete(Task task);
}