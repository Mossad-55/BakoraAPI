using BakoraAPI.Entities.Entities;
using BakoraAPI.Shared.DTOs.Order;
using BakoraAPI.Shared.DTOs.Service;

namespace BakoraAPI.Services.Contracts;

public interface IOrderInterface
{
    Task<IEnumerable<Order?>> GetAllAsync(bool trackChanges);
    Task<Order?> GetByIdAsync(Guid id, bool trackChanges);
    Task CreateOrderAsync(Order order, bool trackChanges);
    Task UpdateOrderAsync(Guid id, OrderDTO order, bool trackChanges);
    Task DeleteOrderAsync(Guid id, bool trackChanges);

}
