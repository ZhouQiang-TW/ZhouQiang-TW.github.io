namespace BlazorApp.Daemon.Commands;

public interface ICommand
{
    Task FetchDataAsync();
}