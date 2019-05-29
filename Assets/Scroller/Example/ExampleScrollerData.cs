using Sharper.Scroller;
using UnityEngine;

/// <summary>
///     Example scroller data class. We are storing a color here which is applied to a prefab when displayed in the scroller
/// </summary>
public class ExampleScrollerData : IScrollerData
{
    public readonly Color Color;

    public ExampleScrollerData(Color color)
    {
        Color = color;
    }
}