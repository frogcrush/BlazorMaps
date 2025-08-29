using Meteion.BlazorMaps.JsInterops.Events;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

/// <summary>
/// An abstract class for beings that are interactive, i.e. they
/// can react on events such as 'click', 'mouseover' etc.
/// </summary>
public abstract class Evented : JsReferenceBase
{
    private const string ClickJsFunction = "click";
    private const string DblClickJsFunction = "dblclick";
    private const string MouseDownJsFunction = "mousedown";
    private const string MouseUpJsFunction = "mouseup";
    private const string MouseOverJsFunction = "mouseover";
    private const string MouseOutJsFunction = "mouseout";
    private const string ContextMenuJsFunction = "contextmenu";
    private const string OffJsFunction = "off";
    protected IEventedJsInterop eventedJsInterop;
    private readonly Dictionary<string, Func<MouseEvent, Task>> _mouseEvents = [];

    public async Task OnClick(Func<MouseEvent, Task> callback) => await On(ClickJsFunction, callback);

    public async Task OnDblClick(Func<MouseEvent, Task> callback) => await On(DblClickJsFunction, callback);

    public async Task OnMouseDown(Func<MouseEvent, Task> callback) => await On(MouseDownJsFunction, callback);

    public async Task OnMouseUp(Func<MouseEvent, Task> callback) => await On(MouseUpJsFunction, callback);

    public async Task OnMouseOver(Func<MouseEvent, Task> callback) => await On(MouseOverJsFunction, callback);

    public async Task OnMouseOut(Func<MouseEvent, Task> callback) => await On(MouseOutJsFunction, callback);

    public async Task OnContextMenu(Func<MouseEvent, Task> callback) => await On(ContextMenuJsFunction, callback);

    private async Task On(string eventType, Func<MouseEvent, Task> callback)
    {
        if (_mouseEvents.ContainsKey(eventType))
        {
            return;
        }

        _mouseEvents.Add(eventType, callback);
        await On(eventType);
    }

    private async Task On(string eventType)
    {
        DotNetObjectReference<Evented> eventedClass = DotNetObjectReference.Create(this);
        await eventedJsInterop.OnCallback(eventedClass, JsReference, eventType);
    }

    public async Task Off(string eventType)
    {
        if (_mouseEvents.ContainsKey(eventType))
        {
            _mouseEvents.Remove(eventType);
            await JsReference.InvokeAsync<IJSObjectReference>(OffJsFunction, eventType);
        }
    }

    [JSInvokable]
    public async Task OnCallback(string eventType, MouseEvent mouseEvent)
    {
        bool isEvented = _mouseEvents.TryGetValue(eventType, out Func<MouseEvent, Task> callback);
        if (isEvented)
        {
            await callback.Invoke(mouseEvent);
        }
    }
}
