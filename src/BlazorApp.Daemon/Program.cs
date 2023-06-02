// See https://aka.ms/new-console-template for more information

using BlazorApp.Daemon.Commands;
using BlazorApp.Daemon.Services;
using BlazorApp.HttpClients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

var host = Host.CreateDefaultBuilder(args).UseSerilog();
host.ConfigureServices(sc =>
{
    sc.AddHttpClient();
    sc.AddSingleton<IDataAccess, DataAccess>();
    sc.AddSingleton<ICommand, BingWallpaperCommand>();
});

var builder = host.Build();
var command = builder.Services.GetRequiredService<ICommand>();
await command.FetchDataAsync();

Log.Logger.Information("Hello, World!");