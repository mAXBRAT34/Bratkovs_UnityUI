using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageResizer : MonoBehaviour
{
    public Slider widthSlider;
    public Slider heightSlider;

    private static RectTransform activeImageRectTransform;
    private static Vector2 originalSize;

    void Start()
    {
        widthSlider.onValueChanged.AddListener(UpdateWidth);
        heightSlider.onValueChanged.AddListener(UpdateHeight);

        widthSlider.minValue = 0.5f;
        widthSlider.maxValue = 1.5f;

        heightSlider.minValue = 0.5f;
        heightSlider.maxValue = 1.5f;

        widthSlider.value = 1.0f;
        heightSlider.value = 1.0f;

        IgnoreSliderSelection(widthSlider);
        IgnoreSliderSelection(heightSlider);
    }

    public static void SetActiveImage(RectTransform newImage)
    {
        if (newImage == null)
        {
            Debug.LogWarning("IestatītAktīvoAttēlu: Mēģinājums iestatīt `null` objektu!");
            return;
        }

        activeImageRectTransform = newImage;
        originalSize = activeImageRectTransform.sizeDelta;
    }

    void UpdateWidth(float value)
    {
        if (activeImageRectTransform == null)
        {
            Debug.LogWarning("AtjauninātPlatumu: `activeImageRectTransform` nav iestatīts!");
            return;
        }

        float newWidth = Mathf.Clamp(originalSize.x * value, 50f, 1000f);
        activeImageRectTransform.sizeDelta = new Vector2(newWidth, activeImageRectTransform.sizeDelta.y);
    }

    void UpdateHeight(float value)
    {
        if (activeImageRectTransform == null)
        {
            Debug.LogWarning("AtjauninātAugstumu: `activeImageRectTransform` nav iestatīts!");
            return;
        }

        float newHeight = Mathf.Clamp(originalSize.y * value, 50f, 1000f);
        activeImageRectTransform.sizeDelta = new Vector2(activeImageRectTransform.sizeDelta.x, newHeight);
    }

    void IgnoreSliderSelection(Slider slider)
    {
        if (slider == null)
        {
            Debug.LogWarning("IgnorētSlīdņaIzvēli: `slider` nav norādīts!");
            return;
        }

        EventTrigger trigger = slider.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        entry.callback.AddListener((eventData) => { EventSystem.current.SetSelectedGameObject(null); });
        trigger.triggers.Add(entry);
    }
}
