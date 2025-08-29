using Meteion.BlazorMaps.JsInterops.Base;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps.JsInterops.Events;

internal class EventedJsInterop : BaseJsInterop, IEventedJsInterop
{
    private const string ONCALLBACK = "onCallback";

    private static readonly string jsFilePath = $"{JsInteropConfig.BaseJsFolder}{JsInteropConfig.EventedFile}";

    public EventedJsInterop(IJSRuntime jsRuntime)
        : base(jsRuntime, jsFilePath)
    {
    }

    public async ValueTask OnCallback(
        DotNetObjectReference<Evented> eventedClass,
        IJSObjectReference evented,
        string eventType)
    {
        IJSObjectReference module = await moduleTask.Value;
        await module.InvokeVoidAsync(ONCALLBACK, eventedClass, evented, eventType);
    }
}
