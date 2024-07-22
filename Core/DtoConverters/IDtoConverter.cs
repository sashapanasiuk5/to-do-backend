using FluentResults;

namespace Core.DtoConverters;

public interface IDtoConverter<TDto, TEntity>
{
    Result<TEntity> Convert(TDto dto);
    Result<TDto> ConvertBack(TEntity entity);
}