using Meteion.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

internal class MapEvented : Evented
{
    public MapEvented(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
    {
        JsReference = jsReference;
        EventedJsInterop = eventedJsInterop;
    }
}
