using DataAccess.Entities;

namespace Core.Interfaces.Repositories;

public interface IStatusRepository
{
    List<Status> GetAll();
}