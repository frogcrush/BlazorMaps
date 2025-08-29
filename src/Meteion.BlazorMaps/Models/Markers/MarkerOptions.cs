﻿using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace Meteion.BlazorMaps;

/// <summary>
/// Determines Marker's properties.
/// </summary>
public class MarkerOptions : InteractiveLayerOptions
{
    public MarkerOptions()
    {
        IconRef = null;
        Keyboard = true;
        Title = string.Empty;
        Alt = string.Empty;
        ZIndexOffset = DefaultZIndexOffset;
        Opacity = DefaultOpacity;
        RiseOnHover = false;
        RiseOffset = DefaultRiseOffset;
        Pane = DefaultPane;
        ShadowPane = DefaultShadowPane;
        BubblingMouseEvents = false;
        Interactive = true;
    }

    private const int DefaultZIndexOffset = 0;
    private const double DefaultOpacity = 1;
    private const int DefaultRiseOffset = 250;
    private const string DefaultPane = "markerPane";
    private const string DefaultShadowPane = "shadowPane";
    private Icon _iconRef;
    [JsonIgnore]
    public Icon IconRef
    {
        get
        {
            return _iconRef;
        }

        init
        {
            _iconRef = value;
            if (value != null)
            {
                Icon = _iconRef.JsReference;
            }
            else
            {
                Icon = null;
            }
        }
    }

    public IJSObjectReference Icon { get; init; }
    public bool Keyboard { get; init; }
    public string Title { get; init; }
    public string Alt { get; init; }
    public int ZIndexOffset { get; init; }
    public double Opacity { get; init; }
    public bool RiseOnHover { get; init; }
    public int RiseOffset { get; init; }
    public string ShadowPane { get; init; }
    public bool Draggable { get; init; }
    public bool AutoPan { get; init; }
    public Point AutoPanPadding { get; init; }
    public int AutoPanSpeed { get; init; }
}
