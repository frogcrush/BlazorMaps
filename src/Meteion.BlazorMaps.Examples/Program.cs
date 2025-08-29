using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Meteion.BlazorMaps.DependencyInjection;

namespace Meteion.BlazorMaps.Examples;

public class Program
{
    public static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("app");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddBlazorLeafletMaps();

        await builder.Build().RunAsync();
    }
}
