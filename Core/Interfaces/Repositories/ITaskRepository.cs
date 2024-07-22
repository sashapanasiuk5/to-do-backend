namespace Core.Interfaces.Repositories;

public interface ITaskRepository
{
    List<Task> GetAll();

    Task GetById(int id);

    void Add(Task task);

    void Update(Task task);

    void DeleteById(int id);
}