using DotnetBaseKit.Domain.Entities;

namespace DotnetBaseKit.Application.DTOs;

public class ExampleResponseDto
{
    public Guid Id { get; set; }
    public string ExampleProperty { get; set; } = string.Empty;

    public static implicit operator ExampleResponseDto(Example entity)
    {
        return new ExampleResponseDto
        {
            Id = entity.Id,
            ExampleProperty = entity.ExampleProperty
        };
    }
}