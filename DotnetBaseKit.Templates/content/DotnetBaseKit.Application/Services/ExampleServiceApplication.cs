
using BASEKIT_COMPONENTS_PACKAGE.Application.Base;
using BASEKIT_COMPONENTS_PACKAGE.Shared.Notifications;
using DotnetBaseKit.Application.DTOs;
using DotnetBaseKit.Domain.Repositories;
using DotnetBaseKit.Application.Extensions;

namespace DotnetBaseKit.Application.Services;

public class ExampleServiceApplication : BaseServiceApplication, IExampleServiceApplication
{

    private readonly IExampleWriteRepository _exampleWriteRepository;
    private readonly IExampleReadRepository _exampleReadRepository;

    public ExampleServiceApplication(
        NotificationContext notificationContext,
        IExampleWriteRepository exampleWriteRepository,
        IExampleReadRepository exampleReadRepository) : base(notificationContext)
    {
        _exampleWriteRepository = exampleWriteRepository;
        _exampleReadRepository = exampleReadRepository;
    }

    public Task CreateExampleAsync(ExampleRequestDto dto)
    {
        dto.Validate();

        if (dto.Invalid)
        {
            _notificationContext.AddNotifications(dto.Notifications);
            return Task.CompletedTask;
        }

        var example = dto.ToEntity();

        return _exampleWriteRepository.InsertAsync(example);
    }

    public async Task<ExampleResponseDto> GetExampleAsync(ExampleRequestDto dto)
    {
        dto.Validate();

        if (dto.Invalid)
        {
            _notificationContext.AddNotifications(dto.Notifications);
            return default!;
        }

        var example = await _exampleReadRepository.GetByIdAsync(dto.Id);

        var exampleResponse = example.ToDto();

        return exampleResponse;
    }
}