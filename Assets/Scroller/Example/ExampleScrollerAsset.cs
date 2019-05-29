//  
// Copyright (c) 2019 Shane Harper
// Licensed under the MIT. See LICENSE file full license information.  
//  

using System;
using Sharper.Scroller;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
///     An example scroller asset script. In this example, clicking on an item will scroll to it
/// </summary>
public class ExampleScrollerAsset : MonoBehaviour, IScrollerPrefab<ExampleScrollerData>, IPointerClickHandler
{
    public RectTransform RectTransform
    {
        get { return _transform; }
    }

    public void SetData(int index, ExampleScrollerData data)
    {
        // Save the index of the item so we can jump to it when clicking it 
        _index = index;
        
        // Update the text and color
        _number.text = index.ToString();
        _image.color = data.Color;
    }

    public void OnReturnToPool()
    {
        // We don't need anything to happen here in the example
    }
    
    #region Click handler 
    
    private int _index;
    public Action<int> ClickHandler;

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickHandler?.Invoke(_index);
    }
    
    #endregion

    #region Inspector

    [SerializeField] private RectTransform _transform;
    [SerializeField] private Image _image;
    [SerializeField] private Text _number;

    #endregion
}