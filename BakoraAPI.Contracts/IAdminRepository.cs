using BakoraAPI.Entities.Entities;

namespace BakoraAPI.Contracts;

public interface IAdminRepository
{
    Task<List<Admin>> GetAllAdminsAsync(bool trackChanges);
    Task<Admin> GetAdminAsync(Guid id, bool trackChanges);
    void DeleteAdminAsync(Admin admin);
    void CreateAdminAsync(Admin admin);
    void UpdateAdminAsync(Admin admin);
}
