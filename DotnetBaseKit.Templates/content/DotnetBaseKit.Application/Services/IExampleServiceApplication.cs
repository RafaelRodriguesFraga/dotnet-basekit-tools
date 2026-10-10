using DotnetBaseKit.Application.DTOs;
using BASEKIT_COMPONENTS_PACKAGE.Application.Base;

namespace DotnetBaseKit.Application.Services;

public interface IExampleServiceApplication : IBaseServiceApplication
{
    Task CreateExampleAsync(ExampleRequestDto dto);
    Task<ExampleResponseDto> GetExampleAsync(ExampleRequestDto dto);

}