using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image itemImage;
    private static Item activeItem;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemImage = GetComponent<Image>();

        if (canvasGroup == null) Debug.LogWarning("CanvasGroup nav!");
        if (itemImage == null) Debug.LogWarning("Image nav!");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SetActiveItem();
        canvasGroup.blocksRaycasts = false;
        SetTransparency(0.7f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 mousePosition);

        rectTransform.localPosition = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        SetTransparency(1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetActiveItem();
        ImageResizer.SetActiveImage(rectTransform);
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
