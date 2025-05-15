using UnityEngine;
using UnityEngine.EventSystems;

public class ItemScaler : MonoBehaviour, IBeginDragHandler
{
    private RectTransform rectTransform;
    private Vector2 originalSize;
    private bool hasResized = false; 

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta; 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!hasResized) 
        {
            rectTransform.sizeDelta = new Vector2(originalSize.x * 2f, originalSize.y);
            hasResized = true;
        }
    }
}
