namespace BakoraAPI.Entities.Exceptions;

public sealed class RefreshTokenException : BadRequestException
{
    public RefreshTokenException() 
        : base("Invalid client request. The tokenDto has some invalid values.")
    {
    }
}
