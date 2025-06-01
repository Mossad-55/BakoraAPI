using BakoraAPI.Shared.DTOs.Requester;

namespace BakoraAPI.Services.Contracts;

public interface IRequesterService
{
    Task<IEnumerable<RequesterDto?>> GetAllAsync(bool trackChanges);
    Task<RequesterDto?> GetByIdAsync(Guid id, bool trackChanges);
    Task CreateAsnyc(Guid id, RequesterRegisterDto dto, bool trackChanges);
    Task UpdateAsync(Guid id, RequesterUpdateDto dto, bool trackChanges);
}
