using BakoraAPI.Contracts;
using BakoraAPI.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakoraAPI.Repository;

internal sealed class RequesterRepository : RepositoryBase<Requester>, IRequesterRepository
{
    public RequesterRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateRequester(Requester requester) => Create(requester);

    public void DeleteRequester(Requester requester) => Delete(requester);

    public async Task<List<Requester>> GetAllRequsterAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .Include(r => r.User)
        .ToListAsync();

    public async Task<Requester> GetRequesterAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.UserId == id, trackChanges)
        .Include(r => r.User)
        .SingleOrDefaultAsync();

    public void UpdateRequester(Requester requester) => Update(requester);
}
