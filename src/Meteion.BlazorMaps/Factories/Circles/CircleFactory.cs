using Meteion.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

internal class CircleFactory : ICircleFactory
{
    private const string CREATE = "L.circle";
    private readonly IJSRuntime _jsRuntime;
    private readonly IEventedJsInterop _eventedJsInterop;

    public CircleFactory(
        IJSRuntime jsRuntime,
        IEventedJsInterop eventedJsInterop)
    {
        _jsRuntime = jsRuntime;
        _eventedJsInterop = eventedJsInterop;
    }

    public async Task<Circle> Create(LatLng latLng)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLng);
        return new Circle(jsReference, _eventedJsInterop);
    }

    public async Task<Circle> Create(LatLng latLng, CircleOptions options)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, latLng, options);
        return new Circle(jsReference, _eventedJsInterop);
    }

    public async Task<Circle> CreateAndAddToMap(LatLng latLng, Map map)
    {
        Circle circle = await Create(latLng);
        await circle.AddTo(map);
        return circle;
    }

    public async Task<Circle> CreateAndAddToMap(LatLng latLng, Map map, CircleOptions options)
    {
        Circle circle = await Create(latLng, options);
        await circle.AddTo(map);
        return circle;
    }
}
