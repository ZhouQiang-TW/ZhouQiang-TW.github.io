using Microsoft.Extensions.Hosting;

namespace BlazorApp.Daemon.Services;

public class DataAccess : IDataAccess
{
    private readonly IHostEnvironment _hostEnvironment;

    public DataAccess(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public Task SaveAsync(string fileName, string data)
    {
        throw new NotImplementedException();
    }
}