using BakoraAPI.Contracts;
using BakoraAPI.Entities.Exceptions;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Services.MappingProfiles;
using BakoraAPI.Shared.DTOs.Provider;

namespace BakoraAPI.Services;

internal sealed class ProviderService : IProviderService
{
    private readonly IRepositoryManager _repository;

    public ProviderService(IRepositoryManager repositoryManager) => _repository = repositoryManager;

    public async Task CreateProviderAsync(Guid id, ProviderRegisterDto dto, bool trackChanges)
    {
        var providerEntity = dto.ToEntity();
        providerEntity.UserId = id;

        _repository.Provider.CreateProvider(providerEntity);

        await _repository.SaveChanges();
    }

    public async Task<IEnumerable<ProviderDto?>> GetAllProviders(bool trackChanges)
    {
        var providersEntity = await _repository.Provider.GetAllProvidersAsync(trackChanges);

        return providersEntity.ToProviderDto();
    }

    public async Task<ProviderDto?> GetByIdAsync(Guid id, bool trackChanges)
    {
        var providerEntity = await _repository.Provider.GetProviderAsync(id, trackChanges) ?? throw new UserNotFoundException(id);

        var providerDto = providerEntity.ToProviderDto();

        return providerDto;
    }

    public async Task UpdateProviderAsync(Guid id, ProviderUpdateDto dto, bool trackChanges)
    {
        var providerEntity = await _repository.Provider.GetProviderAsync(id, trackChanges) ?? throw new UserNotFoundException(id);

        providerEntity.UpdateEntity(dto);

        _repository.Provider.UpdateProvider(providerEntity);

        await _repository.SaveChanges();
    }
}
