namespace BlazorApp.Daemon.Services;

public interface IDataAccess
{
    Task SaveAsync(string fileName, string data);
}