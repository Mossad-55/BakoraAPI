using BakoraAPI.Contracts;
using BakoraAPI.Services.Contracts;

namespace BakoraAPI.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAdminService> _adminService;
    private readonly Lazy<IProviderService> _providerService;
    private readonly Lazy<IRequesterService> _requesterService;
    private readonly Lazy<IServiceInterface> _serviceInterface;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _adminService = new Lazy<IAdminService>(() => new AdminService(repositoryManager));
        _providerService = new Lazy<IProviderService>(() => new ProviderService(repositoryManager));
        _requesterService = new Lazy<IRequesterService>(() => new RequesterService(repositoryManager));
        _serviceInterface = new Lazy<IServiceInterface>(() => new ServiceInterface(repositoryManager));
    }

    public IAdminService AdminService => _adminService.Value;
    public IProviderService ProviderService => _providerService.Value;
    public IRequesterService RequesterService => _requesterService.Value;
    public IServiceInterface ServiceInterface => _serviceInterface.Value;
}
