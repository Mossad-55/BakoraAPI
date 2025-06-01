using BakoraAPI.Shared.DTOs.Provider;

namespace BakoraAPI.Services.Contracts;

public interface IProviderService
{
    Task<IEnumerable<ProviderDto?>> GetAllProviders(bool trackChanges);
    Task<ProviderDto?> GetByIdAsync(Guid id, bool trackChanges);
    Task CreateProviderAsync(Guid id, ProviderRegisterDto dto, bool trackChanges);
    Task UpdateProviderAsync(Guid id, ProviderUpdateDto dto, bool trackChanges);
}
