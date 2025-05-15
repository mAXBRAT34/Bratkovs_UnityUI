using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class SceneChanger2 : MonoBehaviour
{
    public Dropdown characterDropdown;

    void Start()
    {
        if (characterDropdown == null)
        {
            Debug.LogError("Nav DropDown");
            return;
        }

        characterDropdown.onValueChanged.AddListener(ChangeScene);
    }

    public void ChangeScene(int index)
    {
        if (index == 1)
        {
            SceneManager.LoadScene("SampleScene"); 
        }
        else if (index == 0)
        {
            SceneManager.LoadScene("SampleScene 1"); 
        }
        else
        {
            Debug.LogWarning("Выбран неизвестный персонаж!");
        }
    }
}
