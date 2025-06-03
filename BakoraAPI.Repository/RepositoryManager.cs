using BakoraAPI.Contracts;

namespace BakoraAPI.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IAdminRepository> _adminRepository;
    private readonly Lazy<IProviderRepository> _providerRepository;
    private readonly Lazy<IRequesterRepository> _requesterRepository;
    private readonly Lazy<IServiceRepository> _serviceRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(repositoryContext));
        _providerRepository = new Lazy<IProviderRepository>(() => new ProviderRepository(repositoryContext));
        _requesterRepository = new Lazy<IRequesterRepository>(() => new RequesterRepository(repositoryContext));
        _serviceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(repositoryContext));
        _orderRepository=new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
    }

    // Repositories
    public IAdminRepository Admin => _adminRepository.Value;
    public IProviderRepository Provider => _providerRepository.Value;
    public IRequesterRepository Requester => _requesterRepository.Value;
    public IServiceRepository Service => _serviceRepository.Value;
    public IOrderRepository Order => _orderRepository.Value;


    public async Task SaveChanges() => await _repositoryContext.SaveChangesAsync();
}
