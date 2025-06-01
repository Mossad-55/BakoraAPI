using BakoraAPI.Contracts;
using BakoraAPI.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakoraAPI.Repository;

internal sealed class AdminRepository : RepositoryBase<Admin>, IAdminRepository
{
    public AdminRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async void CreateAdminAsync(Admin admin) => Create(admin);

    public void DeleteAdminAsync(Admin admin) => Delete(admin);

    public async Task<Admin> GetAdminAsync(Guid id, bool trackChanges) =>
        await FindByCondition(a => a.UserId == id, trackChanges)
        .Include(a => a.User)
        .SingleOrDefaultAsync();

    public Task<List<Admin>> GetAllAdminsAsync(bool trackChanges) =>
        FindAll(trackChanges)
        .Include(a => a.User)
        .ToListAsync();

    public void UpdateAdminAsync(Admin admin) => Update(admin);
}
