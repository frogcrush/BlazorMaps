using Meteion.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps.JsInterops.IconFactories;

internal class IconFactoryJsInterop : BaseJsInterop, IIconFactoryJsInterop
{
    private const string CREATEDEFAULTICON = "createDefaultIcon";

    private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.IconFactoryFile}";

    public IconFactoryJsInterop(IJSRuntime jsRuntime)
        : base(jsRuntime, jsFilePath)
    {
    }

    public async ValueTask<IJSObjectReference> CreateDefaultIcon()
    {
        IJSObjectReference module = await moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>(CREATEDEFAULTICON);
    }
}
