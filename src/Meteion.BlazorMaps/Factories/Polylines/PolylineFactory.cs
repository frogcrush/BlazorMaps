using Meteion.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

internal class PolylineFactory : IPolylineFactory
{
    private const string CREATE = "L.polyline";
    private readonly IJSRuntime _jsRuntime;
    private readonly IEventedJsInterop _eventedJsInterop;

    public PolylineFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop)
    {
        _jsRuntime = jsRuntime;
        _eventedJsInterop = eventedJsInterop;
    }

    public async Task<Polyline> Create(IEnumerable<LatLng> latLngs)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLngs);
        return new Polyline(jsReference, _eventedJsInterop);
    }

    public async Task<Polyline> Create(IEnumerable<LatLng> latLngs, PolylineOptions options)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLngs, options);
        return new Polyline(jsReference, _eventedJsInterop);
    }

    public async Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map)
    {
        Polyline polyline = await Create(latLngs);
        await polyline.AddTo(map);
        return polyline;
    }

    public async Task<Polyline> CreateAndAddToMap(IEnumerable<LatLng> latLngs, Map map, PolylineOptions options)
    {
        Polyline polyline = await Create(latLngs, options);
        await polyline.AddTo(map);
        return polyline;
    }
}
