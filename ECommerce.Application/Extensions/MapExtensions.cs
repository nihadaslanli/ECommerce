using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Extensions;

public static class MapExtensions
{
    public static Category ToCategory(this CategoryCreateDto createDto)
    {
        return new Category
        {
            Name = createDto.Name
        };
    }

    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
