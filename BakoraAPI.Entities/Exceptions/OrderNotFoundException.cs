namespace BakoraAPI.Entities.Exceptions;

public sealed class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(Guid id) 
        : base($"Order with Id: {id} can't be found.")
    {
    }
}
