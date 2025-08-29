using Meteion.BlazorMaps.JsInterops.Events;
using Meteion.BlazorMaps.JsInterops.IconFactories;
using Meteion.BlazorMaps.JsInterops.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace Meteion.BlazorMaps.DependencyInjection;

/// <summary>
/// It is responsible for providing an app's services
/// collection with its Factories and JsInterops implementations.
/// </summary>
public static class MeteionMapsDependencyInjection
{
    public static IServiceCollection AddBlazorLeafletMaps(this IServiceCollection services)
    {
        AddJsInterops(services);
        AddFactories(services);
        return services;
    }

    private static void AddFactories(IServiceCollection services)
    {
        services.AddTransient<IMarkerFactory, MarkerFactory>();
        services.AddTransient<IIconFactory, IconFactory>();
        services.AddTransient<IPolylineFactory, PolylineFactory>();
        services.AddTransient<IPolygonFactory, PolygonFactory>();
        services.AddTransient<ICircleMarkerFactory, CircleMarkerFactory>();
        services.AddTransient<ICircleFactory, CircleFactory>();
    }

    private static void AddJsInterops(IServiceCollection services)
    {
        services.AddTransient<IMapJsInterop, MapJsInterop>();
        services.AddTransient<IEventedJsInterop, EventedJsInterop>();
        services.AddTransient<IIconFactoryJsInterop, IconFactoryJsInterop>();
    }
}
