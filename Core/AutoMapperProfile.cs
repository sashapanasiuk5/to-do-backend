using AutoMapper;
using Core.DTO.Task;

namespace Core;
using Task = DataAccess.Entities.Task;
public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateOrModifyTaskDto, Task>().ReverseMap();
    }
}