using Meteion.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

internal class MarkerFactory : IMarkerFactory
{
    private const string CREATE = "L.marker";
    private readonly IJSRuntime _jsRuntime;
    private readonly IEventedJsInterop _eventedJsInterop;

    public MarkerFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop)
    {
        _jsRuntime = jsRuntime;
        _eventedJsInterop = eventedJsInterop;
    }

    public async Task<Marker> Create(LatLng latLng)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLng);
        return new Marker(jsReference, _eventedJsInterop);
    }

    public async Task<Marker> Create(LatLng latLng, MarkerOptions options)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLng, options);
        return new Marker(jsReference, _eventedJsInterop);
    }

    public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map)
    {
        Marker marker = await Create(latLng);
        await marker.AddTo(map);
        return marker;
    }

    public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map, MarkerOptions options)
    {
        Marker marker = await Create(latLng, options);
        await marker.AddTo(map);
        return marker;
    }
}
