using BakoraAPI.Contracts;
using BakoraAPI.Services.Contracts;

namespace BakoraAPI.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAdminService> _adminService;
    private readonly Lazy<IProviderService> _providerService;
    private readonly Lazy<IRequesterService> _requesterService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _adminService = new Lazy<IAdminService>(() => new AdminService(repositoryManager));
        _providerService = new Lazy<IProviderService>(() => new ProviderService(repositoryManager));
        _requesterService = new Lazy<IRequesterService>(() => new RequesterService(repositoryManager));
    }

    public IAdminService AdminService => _adminService.Value;
    public IProviderService ProviderService => _providerService.Value;
    public IRequesterService RequesterService => _requesterService.Value;
}
