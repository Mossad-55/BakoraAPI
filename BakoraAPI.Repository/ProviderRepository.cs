using BakoraAPI.Contracts;
using BakoraAPI.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakoraAPI.Repository;

internal sealed class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
{
    public ProviderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateProvider(Provider provider) => Create(provider);

    public void DeleteProvider(Provider provider) => Delete(provider);

    public async Task<List<Provider>> GetAllProvidersAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .Include(p => p.User)
        .ToListAsync();

    public async Task<Provider> GetProviderAsync(Guid id, bool trackChanges) =>
        await FindByCondition(p => p.UserId == id, trackChanges)
        .Include(p => p.User)
        .SingleOrDefaultAsync();

    public void UpdateProvider(Provider provider) => Update(provider);
}
