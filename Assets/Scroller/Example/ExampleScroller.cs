//  
// Copyright (c) 2019 Shane Harper
// Licensed under the MIT. See LICENSE file full license information.  
//  

using Sharper.Scroller;

/// <summary>
///     Example of a scroller. In this example, we set a click handler on the new asset to scroll to an index
/// </summary>
public class ExampleScroller : Scroller<ExampleScrollerAsset, ExampleScrollerData>
{
    protected override void OnNewAssetCreated(ExampleScrollerAsset asset)
    {
        asset.ClickHandler = ScrollTo;
    }
}