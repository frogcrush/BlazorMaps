using Meteion.BlazorMaps.JsInterops.IconFactories;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

internal class IconFactory : IIconFactory
{
    private const string CREATE = "L.icon";
    private readonly IJSRuntime _jsRuntime;
    private readonly IIconFactoryJsInterop _iconFactoryJsInterop;

    public IconFactory(
        IJSRuntime jsRuntime,
        IIconFactoryJsInterop iconFactoryJsInterop)
    {
        _jsRuntime = jsRuntime;
        _iconFactoryJsInterop = iconFactoryJsInterop;
    }

    public async Task<Icon> Create(IconOptions options)
    {
        IJSObjectReference jsReference = await _jsRuntime.InvokeAsync<IJSObjectReference>(CREATE, options);
        return new Icon(jsReference);
    }

    public async Task<Icon> CreateDefault()
    {
        IJSObjectReference jsReference = await _iconFactoryJsInterop.CreateDefaultIcon();
        return new Icon(jsReference);
    }
}
