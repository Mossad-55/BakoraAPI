using BakoraAPI.Shared.DTOs.Admin;

namespace BakoraAPI.Services.Contracts;

public interface IAdminService
{
    Task<IEnumerable<AdminDto?>> GetAllAsync(bool trackChanges);
    Task<AdminDto?> GetByIdAsync(Guid id, bool trackChanges);
    Task CreateAsync(Guid userId, bool trackChanges);
}
