using BakoraAPI.Presentation.ActionFilters;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Shared.DTOs.Service;
using Microsoft.AspNetCore.Mvc;

namespace BakoraAPI.Presentation.Controllers;

[Route("api/services")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServiceManager _service;

    public ServiceController(IServiceManager serviceManager) => _service = serviceManager;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var servicesDto = await _service.ServiceInterface.GetAllAsync(false);

        return Ok(servicesDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var serviceDto = await _service.ServiceInterface.GetByIdAsync(id, false);

        return Ok(serviceDto);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateServiceAsync([FromBody] ServiceCreateDto dto)
    {
        await _service.ServiceInterface.CreateServiceAsync(dto, false);

        return StatusCode(201, new { message = "Created new service successfully" });
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateServiceAsync(Guid id, [FromBody] ServiceUpdateDto dto)
    {
        await _service.ServiceInterface.UpdateServiceAsync(id, dto, true);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteServiceAsync(Guid id)
    {
        await _service.ServiceInterface.DeleteServiceAsync(id, false);

        return NoContent();
    }
}
