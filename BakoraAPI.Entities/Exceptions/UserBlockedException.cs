namespace BakoraAPI.Entities.Exceptions;

public sealed class UserBlockedException : BadRequestException
{
    public UserBlockedException(string email) 
        : base($"This email: {email} has been blocked.")
    {
    }
}
