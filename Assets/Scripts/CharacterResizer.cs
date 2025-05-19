using UnityEngine;
using UnityEngine.UI;

public class CharacterResizer : MonoBehaviour
{
    public RectTransform characterTransform;
    public Slider heightSlider;
    public Slider widthSlider;

    private float originalWidth;
    private float originalHeight;

    void Start()
    {
        // ✅ Проверка на `null`
        if (characterTransform == null)
        {
            Debug.Log("");
            return;
        }

        originalWidth = characterTransform.sizeDelta.x;
        originalHeight = characterTransform.sizeDelta.y;

        heightSlider.onValueChanged.AddListener(UpdateHeight);
        widthSlider.onValueChanged.AddListener(UpdateWidth);

        heightSlider.minValue = 0.5f;
        heightSlider.maxValue = 1.5f;

        widthSlider.minValue = 0.5f;
        widthSlider.maxValue = 1.5f;

        heightSlider.value = 1.0f;
        widthSlider.value = 1.0f;
    }

    void UpdateHeight(float value)
    {
        if (characterTransform == null) return;

        float newHeight = originalHeight * value;
        characterTransform.sizeDelta = new Vector2(characterTransform.sizeDelta.x, newHeight);
    }

    void UpdateWidth(float value)
    {
        if (characterTransform == null) return;

        float newWidth = originalWidth * value;
        characterTransform.sizeDelta = new Vector2(newWidth, characterTransform.sizeDelta.y);
    }
}
