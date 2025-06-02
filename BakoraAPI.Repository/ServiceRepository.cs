using BakoraAPI.Contracts;
using BakoraAPI.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakoraAPI.Repository;

internal sealed class ServiceRepository : RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateService(Service service) => Create(service);

    public void DeleteService(Service service) => Delete(service);

    public async Task<List<Service>> GetAllAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .ToListAsync();


    public async Task<Service> GetByIdAsync(Guid id, bool trackChanges) =>
        await FindByCondition(s => s.Id == id, trackChanges)
        .SingleOrDefaultAsync();

    public void UpdateService(Service service) => Update(service);
}
