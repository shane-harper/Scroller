using UnityEngine;

public class ExampleSceneController : MonoBehaviour
{
    #region Inspector
    
    [SerializeField] private ExampleScroller _topScroller;
    [SerializeField] private ExampleScroller _bottomScroller;
    
    [SerializeField] private int _itemCount = 10;
    [SerializeField] private Gradient _gradient = new Gradient
    {
        colorKeys = new[]
        {
            new GradientColorKey(new Color32(255, 0, 0, 1), 0f),
            new GradientColorKey(new Color32(255, 169, 0, 255), 1f / 6f),
            new GradientColorKey(new Color32(248, 255, 0, 255), 1f / 6f * 2f),
            new GradientColorKey(new Color32(0, 255, 25, 255), 1f / 6f * 3f),
            new GradientColorKey(new Color32(0, 182, 255, 255), 1f / 6f * 4f),
            new GradientColorKey(new Color32(134, 0, 255, 255), 1f / 6f * 5f),
            new GradientColorKey(new Color32(201, 0, 255, 255), 1f)
        }
    };

    private void OnValidate()
    {
        // Regenerate in editor, while playing, when item count changes
        if (Application.isPlaying && (_itemCount != _topScroller.ItemCount || _itemCount != _bottomScroller.ItemCount))
            Start();
    }

    #endregion

    private void Start()
    {
        // Initialize the scroller with our test data
        var exampleData = GenerateExampleData();
        _topScroller.SetItems(exampleData);
        _bottomScroller.SetItems(exampleData);
    }
    
    /// <summary>
    ///     Generate some example data to display in the scroller
    /// </summary>
    private ExampleScrollerData[] GenerateExampleData()
    {
        var data = new ExampleScrollerData[_itemCount];
        for (var i = 0; i < _itemCount; ++i)
            data[i] = new ExampleScrollerData(_gradient.Evaluate(i / (_itemCount-1f)));
        return data;
    }

    /// <summary>
    ///     Listen to key presses and jump to an index
    /// </summary>
    private void Update()
    {
        // Press the number keys to jump to each item
        if (!Input.anyKeyDown) return;
        for (var i = 0; i < _itemCount && i < 10; ++i)
        {
            if (!Input.GetKeyDown(i.ToString())) continue;

            // If holding shift, jump instead of scroll
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _topScroller.JumpTo(i);
                _bottomScroller.JumpTo(i);
            }
            else
            {
                _topScroller.ScrollTo(i);
                _bottomScroller.ScrollTo(i);
            }
        }
    }
}