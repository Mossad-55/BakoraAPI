using BakoraAPI.Contracts;
using BakoraAPI.Entities.Exceptions;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Services.MappingProfiles;
using BakoraAPI.Shared.DTOs.Service;

namespace BakoraAPI.Services;

internal sealed class ServiceInterface : IServiceInterface
{
    private readonly IRepositoryManager _repository;

    public ServiceInterface(IRepositoryManager repositoryManager) => _repository = repositoryManager;

    public async Task CreateServiceAsync(ServiceCreateDto dto, bool trackChanges)
    {
        var serviceEntity = dto.ToEntity();

        _repository.Service.CreateService(serviceEntity);

        await _repository.SaveChanges();
    }

    public async Task DeleteServiceAsync(Guid id, bool trackChanges)
    {
        var serviceEntity = await _repository.Service.GetByIdAsync(id, trackChanges) ?? throw new ServiceNotFoundException(id);

        _repository.Service.DeleteService(serviceEntity);

        await _repository.SaveChanges();
    }

    public async Task<IEnumerable<ServiceDto>> GetAllAsync(bool trackChanges)
    {
        var servicesEntity = await _repository.Service.GetAllAsync(trackChanges);

        return servicesEntity.ToServiceDto();
    }

    public async Task<ServiceDto> GetByIdAsync(Guid id, bool trackChanges)
    {
        var serviceEntity = await _repository.Service.GetByIdAsync(id, trackChanges) ?? throw new ServiceNotFoundException(id);

        return serviceEntity.ToServiceDto();
    }

    public async Task UpdateServiceAsync(Guid id, ServiceUpdateDto dto, bool trackChanges)
    {
        var serviceEntity = await _repository.Service.GetByIdAsync(id, trackChanges) ?? throw new ServiceNotFoundException(id);

        serviceEntity.UpdateEntity(dto);

        _repository.Service.UpdateService(serviceEntity);

        await _repository.SaveChanges();
    }
}
