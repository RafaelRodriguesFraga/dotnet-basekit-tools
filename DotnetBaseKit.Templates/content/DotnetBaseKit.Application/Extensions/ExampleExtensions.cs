using DotnetBaseKit.Application.DTOs;
using DotnetBaseKit.Domain.Entities;

namespace DotnetBaseKit.Application.Extensions
{
    public static class ExampleExtensions
    {
        public static Example ToEntity(this ExampleRequestDto dto)
        {
            return new Example(dto.ExampleProperty);
        }

        public static ExampleResponseDto ToDto(this Example entity)
        {

            return new ExampleResponseDto
            {
                Id = entity.Id,
                ExampleProperty = entity.ExampleProperty,
            };
        }
    }
}