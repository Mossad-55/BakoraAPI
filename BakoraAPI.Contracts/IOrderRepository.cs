using BakoraAPI.Entities.Entities;

namespace BakoraAPI.Contracts;

public interface IOrderRepository
{
    Task<List<Order>> GetAllOrdersAsync(bool trackChanges);
    Task<Order> GetOrderAsync(Guid id, bool trackChanges);
    void DeleteOrderAsync(Order Order);
    void CreateOrderAsync(Order Order);
    void UpdateOrderAsync(Order Order);
}
