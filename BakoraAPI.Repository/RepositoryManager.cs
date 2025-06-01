using BakoraAPI.Contracts;

namespace BakoraAPI.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IAdminRepository> _adminRepository;
    private readonly Lazy<IProviderRepository> _providerRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(repositoryContext));
        _providerRepository = new Lazy<IProviderRepository>(() => new ProviderRepository(repositoryContext));
    }

    // Repositories
    public IAdminRepository Admin => _adminRepository.Value;
    public IProviderRepository Provider => _providerRepository.Value;

    public async Task SaveChanges() => await _repositoryContext.SaveChangesAsync();
}
