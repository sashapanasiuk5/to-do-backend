using AutoMapper;
using DataAccess.Repositories.Interfaces;
using FluentResults;
using MediatR;

namespace Core.Actions.Task.Create;
using DataAccess.Entities;
public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Result<Task>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IStatusRepository _statusRepository;
    private readonly IMapper _mapper;
    public CreateTaskCommandHandler
    (
        ITaskRepository taskRepository,
        IStatusRepository statusRepository,
        IMapper mapper
    )
    {
        _statusRepository = statusRepository;
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    public async Task<Result<Task>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        Task task = _mapper.Map<Task>(request.dto);
        Status? status = _statusRepository.GetById(request.dto.StatusId);
        if(status != null)
        {
            task.Status = status;
            _taskRepository.Add(task);
            _taskRepository.SaveChanges();
            return Result.Ok(task);
        }
        return Result.Fail("Status is not found"); 
    }
}