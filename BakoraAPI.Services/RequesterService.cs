using BakoraAPI.Contracts;
using BakoraAPI.Entities.Exceptions;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Services.MappingProfiles;
using BakoraAPI.Shared.DTOs.Requester;

namespace BakoraAPI.Services;

internal sealed class RequesterService : IRequesterService
{
    private readonly IRepositoryManager _repository;

    public RequesterService(IRepositoryManager repositoryManager) => _repository = repositoryManager;

    public async Task CreateAsnyc(Guid id, RequesterRegisterDto dto, bool trackChanges)
    {
        var requesterEntity = dto.ToEntity();
        requesterEntity.UserId = id;

        _repository.Requester.CreateRequester(requesterEntity);

        await _repository.SaveChanges();
    }

    public async Task<IEnumerable<RequesterDto?>> GetAllAsync(bool trackChanges)
    {
        var requestersEntity = await _repository.Requester.GetAllRequsterAsync(trackChanges);

        return requestersEntity.ToRequsterDto();
    }

    public async Task<RequesterDto?> GetByIdAsync(Guid id, bool trackChanges)
    {
        var requesterEntity = await _repository.Requester.GetRequesterAsync(id, trackChanges) ?? throw new UserNotFoundException(id);

        return requesterEntity.ToRequesterDto();
    }

    public async Task UpdateAsync(Guid id, RequesterUpdateDto dto, bool trackChanges)
    {
        var requesterEntity = await _repository.Requester.GetRequesterAsync(id, trackChanges) ?? throw new UserNotFoundException(id);

        requesterEntity.UpdateEntity(dto);

        _repository.Requester.UpdateRequester(requesterEntity);

        await _repository.SaveChanges();
    }
}
