using UnityEngine;
using UnityEngine.UI;

public class ItemBlocker : MonoBehaviour
{
    public GameObject[] items;
    public Toggle toggle;

    void Start()
    {
        if (toggle == null)
        {
            return;
        }

        if (items == null || items.Length == 0)
        {
            return;
        }

        toggle.onValueChanged.AddListener(ToggleItems);
        ToggleItems(toggle.isOn);
    }

    void ToggleItems(bool isBlocked)
    {
        if (items == null || items.Length == 0) return;

        foreach (GameObject item in items)
        {
            if (item == null) continue; 

            Button button = item.GetComponent<Button>();
            if (button != null) button.interactable = !isBlocked;

            Image image = item.GetComponent<Image>();
            if (image != null)
            {
                Color color = image.color;
                color.a = isBlocked ? 0.0f : 1.0f;
                image.color = color;
            }

            CanvasGroup canvasGroup = item.GetComponent<CanvasGroup>();
            if (canvasGroup == null) canvasGroup = item.AddComponent<CanvasGroup>();

            canvasGroup.interactable = !isBlocked;
            canvasGroup.blocksRaycasts = !isBlocked;
        }
    }
}
