using Meteion.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps.JsInterops.Maps;

internal interface IMapJsInterop : IBaseJsInterop
{
    ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions);
}
