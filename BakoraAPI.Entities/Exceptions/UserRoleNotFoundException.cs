namespace BakoraAPI.Entities.Exceptions;

public sealed class UserRoleNotFoundException : NotFoundException
{
    public UserRoleNotFoundException(string role) 
        : base("The provided role: {role} can't be found.")
    {
    }
}
