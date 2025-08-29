using Meteion.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

internal class CircleMarkerFactory : ICircleMarkerFactory
{
    private const string CREATE = "L.circleMarker";
    private readonly IJSRuntime _jsRuntime;
    private readonly IEventedJsInterop _eventedJsInterop;

    public CircleMarkerFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop)
    {
        _jsRuntime = jsRuntime;
        _eventedJsInterop = eventedJsInterop;
    }

    public async Task<CircleMarker> Create(LatLng latLng)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLng);
        return new CircleMarker(jsReference, _eventedJsInterop);
    }

    public async Task<CircleMarker> Create(LatLng latLng, CircleMarkerOptions options)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLng, options);
        return new CircleMarker(jsReference, _eventedJsInterop);
    }

    public async Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map)
    {
        CircleMarker circleMarker = await Create(latLng);
        await circleMarker.AddTo(map);
        return circleMarker;
    }

    public async Task<CircleMarker> CreateAndAddToMap(LatLng latLng, Map map, CircleMarkerOptions options)
    {
        CircleMarker circleMarker = await Create(latLng, options);
        await circleMarker.AddTo(map);
        return circleMarker;
    }
}
