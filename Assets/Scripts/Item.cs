using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public bool isDraggable = true;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image itemImage;
    private static Item activeItem;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemImage = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SetActiveItem();
        canvasGroup.blocksRaycasts = false;
        SetTransparency(0.7f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        if (rectTransform == null)
        {
            Debug.LogWarning("Item: rectTransform == null");
            return;
        }

        if (rectTransform.parent == null)
        {
            Debug.LogWarning($"Item '{gameObject.name}': rectTransform.parent == null");
            return;
        }

        RectTransform parentRect = rectTransform.parent as RectTransform;
        Camera eventCamera = eventData.pressEventCamera;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect, eventData.position, eventCamera, out Vector2 mousePosition))
        {
            rectTransform.localPosition = mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        SetTransparency(1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ImageResizer imageResizer = FindObjectOfType<ImageResizer>();

        if (imageResizer == null)
        {
            Debug.LogWarning("ImageResizer nav atrasts!");
            return;
        }

        imageResizer.SetActiveImage(rectTransform);
    }


private void SetActiveItem()
    {
        activeItem = this;
    }

    private void SetTransparency(float alpha)
    {
        if (itemImage != null)
        {
            Color color = itemImage.color;
            color.a = alpha;
            itemImage.color = color;
        }
    }
}
