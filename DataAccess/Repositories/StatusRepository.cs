using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories;

public class StatusRepository: IStatusRepository
{
    private readonly AppDbContext _dbContext;

    public StatusRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Status> GetAll()
    {
        return _dbContext.Statuses.ToList();
    }

    public Status? GetById(int id)
    {
        return _dbContext.Statuses.SingleOrDefault(st => st.Id == id);
    }
}