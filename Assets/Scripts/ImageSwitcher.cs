using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSwitcher : MonoBehaviour, IBeginDragHandler
{
    public Image itemImage; 
    public Sprite newImage; 
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        itemImage = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (newImage != null)
        {
            itemImage.sprite = newImage; 
        }

        SetVertical(); 
    }

    private void SetVertical()
    {
        rectTransform.rotation = Quaternion.Euler(0, 0, 0); 
    }
}
