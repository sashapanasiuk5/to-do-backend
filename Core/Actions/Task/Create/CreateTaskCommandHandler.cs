using AutoMapper;
using Core.DomainErrors;
using Core.DTO.Task;
using DataAccess.Repositories.Interfaces;
using FluentResults;
using FluentValidation;
using MediatR;

namespace Core.Actions.Task.Create;
using DataAccess.Entities;
public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Result<Task>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IStatusRepository _statusRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateOrModifyTaskDto> _taskDtoValidator;
    public CreateTaskCommandHandler
    (
        ITaskRepository taskRepository,
        IStatusRepository statusRepository,
        IMapper mapper,
        IValidator<CreateOrModifyTaskDto> taskDtoValidator
            )
    {
        _statusRepository = statusRepository;
        _taskRepository = taskRepository;
        _mapper = mapper;
        _taskDtoValidator = taskDtoValidator;
    }
    public async Task<Result<Task>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var result = _taskDtoValidator.Validate(request.dto);
        if (!result.IsValid)
            return Result.Fail(new ValidationError(result.Errors));
        
        Task task = _mapper.Map<Task>(request.dto);
        Status? status = _statusRepository.GetById(request.dto.StatusId);
        if(status != null)
        {
            task.Status = status;
            _taskRepository.Add(task);
            _taskRepository.SaveChanges();
            return Result.Ok(task);
        }
        return Result.Fail(new NotFoundError(typeof(Status), request.dto.StatusId)); 
    }
}