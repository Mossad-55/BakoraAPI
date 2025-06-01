namespace BakoraAPI.Entities.Exceptions;

public sealed class FileExtensionBadRequest : BadRequestException
{
    public FileExtensionBadRequest() 
        : base("Only .jpg, .jpeg, and .png files are allowed.")
    {
    }
}
