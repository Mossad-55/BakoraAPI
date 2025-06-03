using BakoraAPI.Contracts;
using BakoraAPI.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakoraAPI.Repository;

internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async void CreateOrderAsync(Order order) => Create(order);

    public void DeleteOrderAsync(Order order) => Delete(order);
    public void UpdateOrderAsync(Order Order) => Update(Order);
    public async Task<Order> GetOrderAsync(Guid id, bool trackChanges) =>
        await FindByCondition(s => s.Id == id, trackChanges)
        .SingleOrDefaultAsync();

    public Task<List<Order>> GetAllOrdersAsync(bool trackChanges) =>
        FindAll(trackChanges)
        .Include(a => a.User)
        .ToListAsync();


}
