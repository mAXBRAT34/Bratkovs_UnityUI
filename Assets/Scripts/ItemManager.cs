using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public Slider widthSlider; 
    public Slider heightSlider; 

    private Item activeItem;
    private Vector2 originalSize;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        widthSlider.onValueChanged.AddListener(UpdateWidth);
        heightSlider.onValueChanged.AddListener(UpdateHeight);
    }

    public void SetActiveItem(Item newItem)
    {
        activeItem = newItem;
        originalSize = activeItem.GetComponent<RectTransform>().sizeDelta;
    }

    void UpdateWidth(float value)
    {
        if (activeItem != null)
        {
            float newWidth = Mathf.Max(originalSize.x * value, 50f);
            activeItem.GetComponent<RectTransform>().sizeDelta = new Vector2(newWidth, activeItem.GetComponent<RectTransform>().sizeDelta.y);
        }
    }

    void UpdateHeight(float value)
    {
        if (activeItem != null)
        {
            float newHeight = Mathf.Max(originalSize.y * value, 50f);
            activeItem.GetComponent<RectTransform>().sizeDelta = new Vector2(activeItem.GetComponent<RectTransform>().sizeDelta.x, newHeight);
        }
    }
}
