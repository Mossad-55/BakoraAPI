using BakoraAPI.Entities.ConfigurationModels;
using BakoraAPI.Entities.Entities;
using BakoraAPI.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BakoraAPI.Services;

public class AuthenticationServiceManager : IAuthenticationServiceManager
{
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public AuthenticationServiceManager(UserManager<User> userManager,
        RoleManager<IdentityRole<Guid>> roleManager,
        IOptions<JwtConfiguration> configuration,
        IServiceManager serviceManager)
    {
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, roleManager, serviceManager, configuration));
    }

    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
