using Meteion.BlazorMaps.JsInterops.Events;
using Meteion.BlazorMaps.JsInterops.Maps;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

/// <summary>
/// Presents a control for interacting with a map.
/// </summary>
public partial class Map : ComponentBase
{
    [Inject]
    public IJSRuntime JsRuntime { get; set; }

    [Inject]
    internal IMapJsInterop MapJsInterop { get; set; }

    [Inject]
    internal IEventedJsInterop EventedJsInterop { get; set; }

    internal MapEvented MapEvented { get; set; }

    [Parameter]
    public MapOptions MapOptions { get; set; }

    [Parameter]
    public EventCallback AfterRender { get; set; }

    internal IJSObjectReference MapReference { get; set; }

    private const string GETCENTER = "getCenter";
    private const string GETZOOM = "getZoom";
    private const string GETMINZOOM = "getMinZoom";
    private const string GETMAXZOOM = "getMaxZoom";
    private const string SETVIEW = "setView";
    private const string SETZOOM = "setZoom";
    private const string ZOOMIN = "zoomIn";
    private const string ZOOMOUT = "zoomOut";
    private const string SETZOOMAROUND = "setZoomAround";

    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            MapReference = await MapJsInterop.Initialize(MapOptions);
            MapEvented = new MapEvented(MapReference, EventedJsInterop);
            await AfterRender.InvokeAsync();
        }
    }

    public async Task<LatLng> GetCenter() => await MapReference.InvokeAsync<LatLng>(GETCENTER);

    public async Task<int> GetZoom() => await MapReference.InvokeAsync<int>(GETZOOM);

    public async Task<int> GetMinZoom() => await MapReference.InvokeAsync<int>(GETMINZOOM);

    public async Task<int> GetMaxZoom() => await MapReference.InvokeAsync<int>(GETMAXZOOM);

    public async Task SetView(LatLng latLng) => await MapReference.InvokeAsync<IJSObjectReference>(SETVIEW, latLng);

    public async Task SetZoom(int zoom) => await MapReference.InvokeAsync<IJSObjectReference>(SETZOOM, zoom);

    public async Task ZoomIn(int zoomDelta) => await MapReference.InvokeAsync<IJSObjectReference>(ZOOMIN, zoomDelta);

    public async Task ZoomOut(int zoomDelta) => await MapReference.InvokeAsync<IJSObjectReference>(ZOOMOUT, zoomDelta);

    public async Task SetZoomAround(LatLng latLng, int zoom) => await MapReference.InvokeAsync<IJSObjectReference>(SETZOOMAROUND, latLng, zoom);

    public async Task OnClick(Func<MouseEvent, Task> callback) => await MapEvented.OnClick(callback);

    public async Task OnDblClick(Func<MouseEvent, Task> callback) => await MapEvented.OnDblClick(callback);

    public async Task OnMouseDown(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseDown(callback);

    public async Task OnMouseUp(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseUp(callback);

    public async Task OnMouseOver(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseOver(callback);

    public async Task OnMouseOut(Func<MouseEvent, Task> callback) => await MapEvented.OnMouseOut(callback);

    public async Task OnContextMenu(Func<MouseEvent, Task> callback) => await MapEvented.OnContextMenu(callback);

    public async Task Off(string eventType) => await MapEvented.Off(eventType);
}
