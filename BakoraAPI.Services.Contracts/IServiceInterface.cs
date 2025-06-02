using BakoraAPI.Shared.DTOs.Service;

namespace BakoraAPI.Services.Contracts;

public interface IServiceInterface
{
    Task<IEnumerable<ServiceDto>> GetAllAsync(bool trackChanges);
    Task<ServiceDto> GetByIdAsync(Guid id, bool trackChanges);
    Task CreateServiceAsync(ServiceCreateDto dto, bool trackChanges);
    Task UpdateServiceAsync(Guid id, ServiceUpdateDto dto, bool trackChanges);
    Task DeleteServiceAsync(Guid id, bool trackChanges);
}
