using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ImageResizer : MonoBehaviour
{
    public Slider widthSlider;
    public Slider heightSlider;

    private RectTransform activeImageRectTransform;
    private Vector2 originalSize;

    // ✅ Храним текущие размеры предметов
    private Dictionary<RectTransform, Vector2> objectSizes = new Dictionary<RectTransform, Vector2>();

    void Start()
    {
        if (widthSlider == null || heightSlider == null)
        {
            Debug.Log("");
            return;
        }

        widthSlider.onValueChanged.AddListener(UpdateWidth);
        heightSlider.onValueChanged.AddListener(UpdateHeight);

        widthSlider.minValue = 0.5f;
        widthSlider.maxValue = 2.0f;

        heightSlider.minValue = 0.5f;
        heightSlider.maxValue = 2.0f;

        IgnoreSliderSelection(widthSlider);
        IgnoreSliderSelection(heightSlider);
    }

    public void SetActiveImage(RectTransform newImage)
    {
        if (newImage == null)
        {
            Debug.Log("");
            return;
        }

        activeImageRectTransform = newImage;

        // ✅ Если объект уже изменялся – загружаем его сохранённые размеры
        if (objectSizes.ContainsKey(newImage))
        {
            activeImageRectTransform.sizeDelta = objectSizes[newImage];
        }
        else
        {
            originalSize = newImage.sizeDelta;
            objectSizes[newImage] = originalSize;
        }

        // ✅ `Slider` показывает текущий масштаб предмета
        widthSlider.value = activeImageRectTransform.sizeDelta.x / originalSize.x;
        heightSlider.value = activeImageRectTransform.sizeDelta.y / originalSize.y;
    }

    void UpdateWidth(float value)
    {
        if (activeImageRectTransform == null) return;

        float newWidth = originalSize.x * value;
        activeImageRectTransform.sizeDelta = new Vector2(newWidth, activeImageRectTransform.sizeDelta.y);

        // ✅ Сохраняем текущий размер предмета
        objectSizes[activeImageRectTransform] = activeImageRectTransform.sizeDelta;
    }

    void UpdateHeight(float value)
    {
        if (activeImageRectTransform == null) return;

        float newHeight = originalSize.y * value;
        activeImageRectTransform.sizeDelta = new Vector2(activeImageRectTransform.sizeDelta.x, newHeight);

        // ✅ Сохраняем текущий размер предмета
        objectSizes[activeImageRectTransform] = activeImageRectTransform.sizeDelta;
    }

    void IgnoreSliderSelection(Slider slider)
    {
        if (slider == null)
        {
            Debug.Log("");
            return;
        }

        EventTrigger trigger = slider.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        entry.callback.AddListener((eventData) => { EventSystem.current.SetSelectedGameObject(null); });
        trigger.triggers.Add(entry);
    }
}
