using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseChar : MonoBehaviour
{
    public TMP_Dropdown characterDropdown;
    public Image characterImage;
    public Sprite[] characterSprites; // ������ ����������� ����������

    private void Start()
    {
        // ��� ��������� ������ �������� `ChangeCharacter`
        characterDropdown.onValueChanged.AddListener(ChangeCharacter);
    }

    public void ChangeCharacter(int index)
    {
        if (index >= 0 && index < characterSprites.Length)
        {
            characterImage.sprite = characterSprites[index]; // ������ �����������
        }
    }
}
