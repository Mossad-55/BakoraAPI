using Microsoft.AspNetCore.Http;

namespace BakoraAPI.Services.Contracts;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file);
    void DeleteFile(string path);
}
