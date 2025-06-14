﻿namespace BakoraAPI.Contracts;

public interface IRepositoryManager
{
    // Repositories
    IAdminRepository Admin { get; }
    IProviderRepository Provider { get; }
    IRequesterRepository Requester { get; }
    IServiceRepository Service { get; }
        
    Task SaveChanges();
}
