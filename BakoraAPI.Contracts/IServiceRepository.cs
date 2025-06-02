using BakoraAPI.Entities.Entities;

namespace BakoraAPI.Contracts;

public interface IServiceRepository 
{
    Task<List<Service>> GetAllAsync(bool trackChanges);
    Task<Service> GetByIdAsync(Guid id, bool trackChanges);
    void CreateService(Service service);
    void UpdateService(Service service);
    void DeleteService(Service service);
}
