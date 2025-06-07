using BakoraAPI.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BakoraAPI.Presentation.Controllers;

[Route("api/providers")]
[ApiController]
[Authorize(Roles = "Provider, Admin")]
public class ProviderController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProviderController(IServiceManager serviceManager) => _service = serviceManager;

    [HttpGet]
    public async Task<IActionResult> GetAllProviders()
    {
        var providersDto = await _service.ProviderService.GetAllProviders(false);

        return Ok(providersDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProvider(Guid id)
    {
        var providerDto = await _service.ProviderService.GetByIdAsync(id, false);

        return Ok(providerDto);
    }
}
