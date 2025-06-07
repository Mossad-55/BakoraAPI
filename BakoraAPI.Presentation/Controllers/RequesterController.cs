using BakoraAPI.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BakoraAPI.Presentation.Controllers;

[Route("api/requesters")]
[ApiController]
[Authorize(Roles = "Admin, Requester")]
public class RequesterController : ControllerBase
{
    private readonly IServiceManager _service;

    public RequesterController(IServiceManager serviceManager) => _service = serviceManager;

    [HttpGet]
    public async Task<IActionResult> GetAllRequesters()
    {
        var requestersDto = await _service.RequesterService.GetAllAsync(false);

        return Ok(requestersDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRequester(Guid id)
    {
        var requesterDto = await _service.RequesterService.GetByIdAsync(id, false);

        return Ok(requesterDto);
    }
}
