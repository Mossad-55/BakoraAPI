using BakoraAPI.Contracts;
using BakoraAPI.Entities.Entities;
using BakoraAPI.Entities.Exceptions;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Services.MappingProfiles;
using BakoraAPI.Shared.DTOs.Admin;

namespace BakoraAPI.Services;

internal sealed class AdminService : IAdminService
{
    private readonly IRepositoryManager _repository;

    public AdminService(IRepositoryManager repository) => _repository = repository; 


    public async Task CreateAsync(Guid userId, bool trackChanges)
    {
        var admin = new Admin
        {
            UserId = userId
        };

        _repository.Admin.CreateAdminAsync(admin);

        await _repository.SaveChanges();
    }

    public async Task<IEnumerable<AdminDto?>> GetAllAsync(bool trackChanges)
    {
        var adminsEntity = await _repository.Admin.GetAllAdminsAsync(trackChanges);

        return adminsEntity.ToAdminDto();
    }

    public async Task<AdminDto?> GetByIdAsync(Guid id, bool trackChanges)
    {
        var adminEntity = await _repository.Admin.GetAdminAsync(id, trackChanges) ?? throw new UserNotFoundException(id);

        var adminDto = adminEntity.ToAdminDto();

        return adminDto;
    }
}
