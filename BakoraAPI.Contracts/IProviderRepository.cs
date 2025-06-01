using BakoraAPI.Entities.Entities;

namespace BakoraAPI.Contracts;

public interface IProviderRepository
{
    Task<List<Provider>> GetAllProvidersAsync(bool trackChanges);
    Task<Provider> GetProviderAsync(Guid id, bool trackChanges);
    void DeleteProvider(Provider provider);
    void CreateProvider(Provider provider);
    void UpdateProvider(Provider provider);
}
