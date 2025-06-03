using BakoraAPI.Entities.Entities;
using BakoraAPI.Presentation.ActionFilters;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Shared.DTOs.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakoraAPI.Presentation.Controllers;


[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IServiceManager _services;

    public OrderController(IServiceManager serviceManager) => _services = serviceManager;

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _services.OrderInterface.GetAllAsync(false);

        return Ok(orders);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var order = await _services.OrderInterface.GetByIdAsync(id, false);

        return Ok(order);
    }
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateOrderAsync([FromBody] Order order)
    {
        await _services.OrderInterface.CreateOrderAsync(order, false);

        return StatusCode(201, new { message = "Created new service successfully" });
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateOrderAsync(Guid id, [FromBody]Order order)
    {
        await _services.OrderInterface.UpdateOrderAsync(id, order, true);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrderAsync(Guid id)
    {
        await _services.OrderInterface.DeleteOrderAsync(id, false);

        return NoContent();
    }
}
