using BakoraAPI.Contracts;
using BakoraAPI.Entities.Entities;
using BakoraAPI.Entities.Exceptions;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Services.MappingProfiles;
using BakoraAPI.Shared.DTOs.Order;

namespace BakoraAPI.Services;

internal sealed class OrderInterface : IOrderInterface
{
    private readonly IRepositoryManager _repository;

    public OrderInterface(IRepositoryManager repository) => _repository = repository;



    public async Task CreateOrderAsync(Order order, bool trackChanges)
    {

        _repository.Order.CreateOrderAsync(order);

        await _repository.SaveChanges();
    }

    public async Task DeleteOrderAsync(Guid id, bool trackChanges)
    {
        var orderEntity = await _repository.Order.GetOrderAsync(id, trackChanges) ?? throw new OrderNotFoundException(id);

        _repository.Order.DeleteOrderAsync(orderEntity);

        await _repository.SaveChanges();
    }
    public async Task UpdateOrderAsync(Guid id, OrderDTO order, bool trackChanges)
    {
        var orderEntity = await _repository.Order.GetOrderAsync(id, trackChanges) ?? throw new OrderNotFoundException(id);
        orderEntity.UpdateEntity(order);
 
        _repository.Order.UpdateOrderAsync(orderEntity);

        await _repository.SaveChanges();
    }
    public async Task<IEnumerable<Order?>> GetAllAsync(bool trackChanges)
    {
        var orderEntitiy = await _repository.Order.GetAllOrdersAsync(trackChanges);

        return orderEntitiy;
    }

    public async Task<Order?> GetByIdAsync(Guid id, bool trackChanges)
    {
        var orderEntitiy = await _repository.Order.GetOrderAsync(id, trackChanges) ?? throw new OrderNotFoundException(id);


        return orderEntitiy;
    }

    
}
