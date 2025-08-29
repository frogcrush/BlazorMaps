using Meteion.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

internal class PolygonFactory : IPolygonFactory
{
    private const string CREATE = "L.polygon";
    private readonly IJSRuntime _jsRuntime;
    private readonly IEventedJsInterop _eventedJsInterop;

    public PolygonFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop)
    {
        _jsRuntime = jsRuntime;
        _eventedJsInterop = eventedJsInterop;
    }

    public async Task<Polygon> Create(IEnumerable<LatLng> latLngs)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLngs);
        return new Polygon(jsReference, _eventedJsInterop);
    }

    public async Task<Polygon> Create(IEnumerable<LatLng> latLngs, PolylineOptions options)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLngs, options);
        return new Polygon(jsReference, _eventedJsInterop);
    }

    public async Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
    {
        Polygon polygon = await Create(latLngs);
        await polygon.AddTo(map);
        return polygon;
    }

    public async Task<Polygon> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
    {
        Polygon polygon = await Create(latLngs, options);
        await polygon.AddTo(map);
        return polygon;
    }
}
