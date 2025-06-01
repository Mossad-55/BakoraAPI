using BakoraAPI.Contracts;
using BakoraAPI.Services.Contracts;

namespace BakoraAPI.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAdminService> _adminService;
    private readonly Lazy<IProviderService> _providerService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _adminService = new Lazy<IAdminService>(() => new AdminService(repositoryManager));
        _providerService = new Lazy<IProviderService>(() => new ProviderService(repositoryManager));
    }

    public IAdminService AdminService => _adminService.Value;
    public IProviderService ProviderService => _providerService.Value;
}
