using DotnetBaseKit.Application.DTOs;
using DotnetBaseKit.Application.Services;
using BASEKIT_COMPONENTS_PACKAGE.Api.Base;
using BASEKIT_COMPONENTS_PACKAGE.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBaseKit.Api.Controllers;

[ApiController]
[Route("api/example")]
public class ExampleController : ApiControllerBase
{
    private readonly IExampleServiceApplication _exampleServiceApplication;

    public ExampleController(IResponseFactory responseFactory, IExampleServiceApplication exampleServiceApplication) : base(responseFactory)
    {
        _exampleServiceApplication = exampleServiceApplication;
    }

    [HttpGet]
    public async Task<IActionResult> GetExampleAsync([FromQuery] ExampleRequestDto dto)
    {

        var example = await _exampleServiceApplication.GetExampleAsync(dto);

        return ResponseOk(example);        
    }

    [HttpPost]
    public async Task<IActionResult> CreateExampleAsync([FromBody] ExampleRequestDto dto)
    {
        await _exampleServiceApplication.CreateExampleAsync(dto);
        
        return ResponseCreated();
    }
}
