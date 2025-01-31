using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IStatusRepository
{
    List<Status> GetAll();

    Status? GetById(int id);
}