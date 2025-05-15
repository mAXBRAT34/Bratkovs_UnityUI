using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseChar : MonoBehaviour
{
    public TMP_Dropdown characterDropdown;
    public Image characterImage;
    public Sprite[] robloxSprites; 

    private void Start()
    {
        characterDropdown.onValueChanged.AddListener(ChangeCharacter);
    }

    public void ChangeCharacter(int index)
    {
        if (index >= 0 && index < robloxSprites.Length)
        {
            characterImage.sprite = robloxSprites[index]; 
            characterImage.gameObject.SetActive(true); 
        }

    }
}

