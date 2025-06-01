using BakoraAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BakoraAPI.Presentation.Controllers;

[Route("api/admins")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IServiceManager _services;

    public AdminController(IServiceManager serviceManager) => _services = serviceManager;

    [HttpGet]
    public async Task<IActionResult> GetAllAdmins()
    {
        var adminsDto = await _services.AdminService.GetAllAsync(false);

        return Ok(adminsDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAdmin(Guid id)
    {
        var adminDto = await _services.AdminService.GetByIdAsync(id, false);

        return Ok(adminDto);
    }
}
