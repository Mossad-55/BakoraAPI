using BakoraAPI.Entities.Entities;

namespace BakoraAPI.Contracts;

public interface IRequesterRepository
{
    Task<List<Requester>> GetAllRequsterAsync(bool trackChanges);
    Task<Requester> GetRequesterAsync(Guid id, bool trackChanges);
    void DeleteRequester(Requester requester);
    void UpdateRequester(Requester requester);
    void CreateRequester(Requester requester);
}
