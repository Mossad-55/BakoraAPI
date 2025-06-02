namespace BakoraAPI.Entities.Exceptions;

public sealed class ServiceNotFoundException : NotFoundException
{
    public ServiceNotFoundException(Guid id) 
        : base($"Service with Id: {id} can't be found.")
    {
    }
}
