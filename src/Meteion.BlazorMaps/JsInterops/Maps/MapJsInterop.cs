using Meteion.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps.JsInterops.Maps;

internal class MapJsInterop : BaseJsInterop, IMapJsInterop
{
    private const string INITIALIZE = "initialize";

    private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.MapFile}";

    public MapJsInterop(IJSRuntime jsRuntime)
        : base(jsRuntime, jsFilePath)
    {
    }

    public async ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions)
    {
        IJSObjectReference module = await moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>(INITIALIZE, mapOptions);
    }
}
