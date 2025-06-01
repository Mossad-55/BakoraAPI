namespace BakoraAPI.Services.Contracts;

public interface IServiceManager
{
    IAdminService AdminService { get; }
    IProviderService ProviderService { get; }
    IRequesterService RequesterService { get; }
}
