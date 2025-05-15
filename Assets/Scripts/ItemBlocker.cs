using UnityEngine;
using UnityEngine.UI;

public class ItemBlocker : MonoBehaviour
{
    public GameObject[] items;  
    public Toggle toggle;       

    void Start()
    {
        toggle.onValueChanged.AddListener(ToggleItems);
        ToggleItems(toggle.isOn);
    }

    void ToggleItems(bool isBlocked)
    {
        foreach (GameObject item in items)
        {
            if (item.GetComponent<Button>() != null)
            {
                item.GetComponent<Button>().interactable = !isBlocked; 
            }

            if (item.GetComponent<Image>() != null)
            {
                Color color = item.GetComponent<Image>().color;
                color.a = isBlocked ? 0.0f : 1.0f; 
                item.GetComponent<Image>().color = color;
            }

            if (item.GetComponent<CanvasGroup>() == null)
            {
                item.AddComponent<CanvasGroup>(); 
            }

            item.GetComponent<CanvasGroup>().interactable = !isBlocked; 
            item.GetComponent<CanvasGroup>().blocksRaycasts = !isBlocked; 
        }
    }
}
