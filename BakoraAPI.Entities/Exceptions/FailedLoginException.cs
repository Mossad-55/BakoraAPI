namespace BakoraAPI.Entities.Exceptions;

public sealed class FailedLoginException : BadRequestException
{
    public FailedLoginException() 
        : base("Invalid Email or Password. Please try again.")
    {
    }
}
