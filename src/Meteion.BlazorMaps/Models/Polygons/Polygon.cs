using Meteion.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

/// <summary>
/// A class for drawing polygon overlays on a Map.
/// </summary>
public class Polygon : Polyline
{
    internal Polygon(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        : base(jsReference, eventedJsInterop)
    {
    }
}
