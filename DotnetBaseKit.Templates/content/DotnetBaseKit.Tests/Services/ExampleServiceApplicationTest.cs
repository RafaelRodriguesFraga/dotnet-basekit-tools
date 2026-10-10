using DotnetBaseKit.Application.DTOs;
using DotnetBaseKit.Application.Services;
using BASEKIT_COMPONENTS_PACKAGE.Shared.Notifications;
using DotnetBaseKit.Domain.Entities;
using DotnetBaseKit.Domain.Repositories;
using Moq;

namespace DotnetBaseKit.Tests.Services;

public class ExampleServiceApplicationTests
{
    private readonly Mock<IExampleReadRepository> _readRepositoryMock;
    private readonly Mock<IExampleWriteRepository> _writeRepositoryMock;
    private readonly NotificationContext _notificationContext;
    private readonly ExampleServiceApplication _service;

    public ExampleServiceApplicationTests()
    {
        _readRepositoryMock = new Mock<IExampleReadRepository>();
        _writeRepositoryMock = new Mock<IExampleWriteRepository>();
        _notificationContext = new NotificationContext();
        _service = new ExampleServiceApplication(_notificationContext, _writeRepositoryMock.Object, _readRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateExampleAsync_WhenDtoIsValid_ShouldInsertExample()
    {
        var dto = new ExampleRequestDto
        {
            ExampleProperty = "Example value"
        };

        await _service.CreateExampleAsync(dto);

        _writeRepositoryMock.Verify(x => x.InsertAsync(It.Is<Example>(e => e.ExampleProperty == dto.ExampleProperty)), Times.Once);
    }

    [Fact]
    public async Task GetExampleAsync_WhenRecordExists_ShouldReturnMappedDto()
    {
        var expectedExample = new Example("Example value");
        var expectedId = Guid.NewGuid();

        _readRepositoryMock.Setup(x => x.GetByIdAsync(expectedId)).ReturnsAsync(expectedExample);

        var dto = new ExampleRequestDto
        {
            Id = expectedId,
            ExampleProperty = "Example value"
        };

        var result = await _service.GetExampleAsync(dto);

        Assert.NotNull(result);
        Assert.Equal(expectedExample.Id, result.Id);
        Assert.Equal(expectedExample.ExampleProperty, result.ExampleProperty);
        
        _readRepositoryMock.Verify(x => x.GetByIdAsync(expectedId), Times.Once);
    }
}
