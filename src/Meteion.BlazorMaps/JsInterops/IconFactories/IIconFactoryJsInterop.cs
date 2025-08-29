using Microsoft.JSInterop;

namespace Meteion.BlazorMaps.JsInterops.IconFactories;

internal interface IIconFactoryJsInterop
{
    ValueTask<IJSObjectReference> CreateDefaultIcon();
}
