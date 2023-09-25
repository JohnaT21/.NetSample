using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Serilog;

namespace TestProject.API;

public class Program
{
    private static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            // .ConfigureAppConfiguration((host, config) =>
            // {
            //     config.AddJsonFile("appsettings.json");
            //     config.AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json");
            // })
            .UseStartup<Startup>()
            .UseSerilog();
}