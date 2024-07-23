using AutoMapper;
using Core.DTO.Task;

namespace Core;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateOrModifyTaskDto, Task>();
    }
}